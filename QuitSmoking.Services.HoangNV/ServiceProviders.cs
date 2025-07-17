namespace QuitSmoking.Services.HoangNV
{
    public interface IServiceProviders
    {
        ICreatePlanQuitSmokingHoangNvService CreatePlanQuitSmokingHoangNvService { get; }

        IPlanQuitHoangNVService PlanQuitHoangNvService { get; }

        IQuitMethodHoangnvService QuitMethodHoangNvService { get; }

        IRecordProccessHoangnvService RecordProcessHoangNvService { get; }
    }
    public class ServiceProviders : IServiceProviders
    {
      
        private ICreatePlanQuitSmokingHoangNvService _createPlanQuitSmokingHoangNvService;
        private IPlanQuitHoangNVService _planQuitHoangNvService;
        private IQuitMethodHoangnvService _quitMethodHoangNvService;
        private IRecordProccessHoangnvService _recordProcessHoangNvService;

        public ServiceProviders()
        {

        }

        public ICreatePlanQuitSmokingHoangNvService CreatePlanQuitSmokingHoangNvService
        {
            get
            {
                return _createPlanQuitSmokingHoangNvService ??= new CreatePlanQuitSmokingHoangNvService();
            }
        }


        public IPlanQuitHoangNVService PlanQuitHoangNvService
        {
            get
            {
                return _planQuitHoangNvService ??= new PlanQuitHoangnvService();
            }
        }


        public IQuitMethodHoangnvService QuitMethodHoangNvService
        {
            get
            {
                return _quitMethodHoangNvService ??= new QuitMethodHoangnvService();
            }
        }

        public IRecordProccessHoangnvService RecordProcessHoangNvService
        {
            get
            {
                return _recordProcessHoangNvService ??= new RecordProcessHoangnvService();
            }
        }
    }
}
