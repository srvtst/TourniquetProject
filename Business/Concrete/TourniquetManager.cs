using BusinessLayer.Abstract;
using BusinessLayer.Contants;
using BusinessLayer.MessageBroker.RabbitMQ.Abstract;
using CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using EntitiesLayer.Concrete;
using Microsoft.Extensions.Logging;
using System.Reflection;
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
        string key = "Tourniquet";
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
            if (_redisService.IsKeyDb(key, 0))
            {
                _redisService.RemoveCache<Tourniquet>(key, 0);
            }
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
            //string methodName = string.Format($"{MethodBase.GetCurrentMethod().Name}");
            //string key = $"{methodName}()";
            if (!_redisService.IsKeyDb(key, 0))
            {
                var DbResult = _tourniquetDal.GetAll();
                _logger.LogInformation("Veri Tabanından Listeleme Yapıldı.");
                var jsonResult = JsonSerializer.Serialize(DbResult);
                _redisService.SetCache(key, jsonResult, 0, 250);
                return new SuccessDataResult<List<Tourniquet>>(DbResult, Message.TourniquetGetAll);
            }
            else
            {
                var cacheResult = _redisService.GetListCache<Tourniquet>(key, 0);
                _logger.LogInformation($"{key} Bilgisine göre Cacheten Listeleme Yapıldı.");
                return new SuccessDataResult<List<Tourniquet>>(cacheResult);
            }
        }

        public IDataResult<Tourniquet> GetByTourniquet(int id)
        {
            //string methodName = string.Format($"{MethodBase.GetCurrentMethod().Name}");
            //string key = $"{methodName}()";
            if (!_redisService.IsKeyDb(key, 0))
            {
                var DbResult = _tourniquetDal.GetByTourniquet(id);
                _logger.LogInformation("Veri Tabanından Listeleme Yapıldı.");
                var jsonResult = JsonSerializer.Serialize(DbResult);
                _redisService.SetCache(key, jsonResult, 0, 3);
                return new SuccessDataResult<Tourniquet>(DbResult);
            }
            else
            {
                var cacheResult = _redisService.GetCache<Tourniquet>(key, 0);
                _logger.LogInformation($"{key} Bilgisine göre Cacheten Listeleme Yapıldı.");
                return new SuccessDataResult<Tourniquet>(cacheResult);
            }
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