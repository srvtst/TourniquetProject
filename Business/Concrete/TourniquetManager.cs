using BusinessLayer.Abstract;
using BusinessLayer.Contants;
using BusinessLayer.Mailing.Abstract;
using BusinessLayer.MessageBroker.RabbitMQ.Abstract;
using CoreLayer.CrossCuttingConcerns.Caching.Abstract;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using EntitiesLayer.Concrete;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace BusinessLayer.Concrete
{
    public class TourniquetManager : ITourniquetService
    {
        private readonly ITourniquetDal _tourniquetDal;
        private readonly ILogger<TourniquetManager> _logger;
        private readonly ICacheManager _cacheManager;
        private readonly IPublisherService _publisherService;
        private readonly IMailSender _mailSender;
        private readonly IConsumerService _consumerService;
        public TourniquetManager(ITourniquetDal tourniquetDal, ILogger<TourniquetManager> logger, ICacheManager cacheManager, IPublisherService publisherService
            , IMailSender mailSender, IConsumerService consumerService)
        {
            _tourniquetDal = tourniquetDal;
            _logger = logger;
            _publisherService = publisherService;
            _mailSender = mailSender;
            _cacheManager = cacheManager;
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
            var method = MethodBase.GetCurrentMethod();
            var methodName = string.Format($"{method.ReflectedType.FullName}.{method.Name}");
            var parameters = method.GetParameters().Select(o => o?.ToString() ?? "<<null>>");
            var key = $"{methodName}({parameters})";
            if (!_cacheManager.IsThere(key))
            {
                var result = _tourniquetDal.GetAll();
                _cacheManager.Add(key, result, 40);
                _logger.LogInformation("Veri tabanından listeleme yapıldı.");
                return new SuccessDataResult<List<Tourniquet>>(result, Message.TourniquetGetAll);
            }
            else
            {
                _logger.LogInformation("Cache ten listeleme yapıldı.");
                return new SuccessDataResult<List<Tourniquet>>(_cacheManager.Get<List<Tourniquet>>(key));
            }
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