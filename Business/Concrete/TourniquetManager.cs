using BusinessLayer.Abstract;
using BusinessLayer.Contants;
using BusinessLayer.MessageBroker.RabbitMQ.Abstract;
using CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using EntitiesLayer.Concrete;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BusinessLayer.Concrete
{
    public class TourniquetManager : ITourniquetService
    {
        private readonly ITourniquetDal _tourniquetDal;
        private readonly ILogger<TourniquetManager> _logger;
        private readonly IPublisherService _publisherService;
        private readonly IConsumerService _consumerService;
        private readonly IRedisCacheService _redisService;
        string key = "name";
        int db = 1;
        public TourniquetManager(ITourniquetDal tourniquetDal, ILogger<TourniquetManager> logger, IRedisCacheService redisCacheService
            , IPublisherService publisherService, IConsumerService consumerService)
        {
            _tourniquetDal = tourniquetDal;
            _logger = logger;
            _redisService = redisCacheService;
            _publisherService = publisherService;
            _consumerService = consumerService;
        }

        public IResult Entry(Tourniquet tourniquet)
        {
            _tourniquetDal.Entry(tourniquet);
            _publisherService.Publish(tourniquet);
            _consumerService.Start();
            _logger.LogInformation("Turnikeden giriş yapıldı");
            return new Result(true, Message.TourniquetEntry);
        }

        public IResult Exit(Tourniquet tourniquet)
        {
            _tourniquetDal.Exit(tourniquet);
            //_publisherService.Publish(tourniquet);
            _logger.LogInformation("Turnikeden çıkış yapıldı");
            //_consumerService.Start();
            return new Result(true, Message.TourniquetExit);
        }

        public IDataResult<List<Tourniquet>> GetAll()
        {
            var result = _tourniquetDal.GetAll();
            _logger.LogInformation("Veri Tabanından Listeleme Yapıldı.");
            var jsonResult = JsonSerializer.Serialize(result);
            _redisService.SetCache(key, jsonResult, db, 2);
            return new SuccessDataResult<List<Tourniquet>>(result, Message.TourniquetGetAll);
        }

        public IDataResult<Tourniquet> GetByTourniquet(int id)
        {
            var result = _tourniquetDal.GetByTourniquet(id);
            return new SuccessDataResult<Tourniquet>(result);
        }

        public IDataResult<List<Tourniquet>> GetDayTourniquet(DateTime dateTime)
        {
            var result = _tourniquetDal.GetDayTourniquet(dateTime);
            return new SuccessDataResult<List<Tourniquet>>(result, Message.TourniquetGetDay);
        }

        public IDataResult<List<Tourniquet>> GetMonthTourniquet(DateTime dateTime)
        {
            var result = _tourniquetDal.GetMonthTourniquet(dateTime);
            return new SuccessDataResult<List<Tourniquet>>(result, Message.TourniquetGetMonth);
        }
    }
}