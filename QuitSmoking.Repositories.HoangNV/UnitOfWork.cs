using QuitSmoking.Repositories.HoangNV;
using QuitSmoking.Repositories.HoangNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuitSmoking.Repositories.Hoangnv
{
    public interface IUnitOfWork : IDisposable
    {

        CreatePlanQuitSmokingHoangNvRepo CreatePlanQuitSmokingHoangNvRepo { get; }

        PlanQuitMethodHoangNvRepo PlanQuitMethodHoangNvRepo { get; }

        QuitMethodHoangNvRepo QuitMethodHoangNvRepo { get; }

        RecordProcessHoangNvRepo RecordProcessHoangNv { get; }

        SystemUserRepo UserHoangNvRepo { get; }
        int SaveChangeWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();

    }

    public class UnitOfWork : IUnitOfWork
    {
               private readonly Su25Prn231Se1723G5Context _context;
               private readonly CreatePlanQuitSmokingHoangNvRepo _createPlanQuitSmokingHoangNvRepo;
        private readonly PlanQuitMethodHoangNvRepo _planQuitMethodHoangNvRepo;
        private readonly QuitMethodHoangNvRepo _quitMethodHoangNvRepo;
        private readonly RecordProcessHoangNvRepo _recordProcessHoangNvRepo;
        private readonly SystemUserRepo _userHoangNvRepo;

        public UnitOfWork() => _context ??= new Su25Prn231Se1723G5Context();


        public CreatePlanQuitSmokingHoangNvRepo CreatePlanQuitSmokingHoangNvRepo
        {
            get
            {
                return _createPlanQuitSmokingHoangNvRepo ?? new CreatePlanQuitSmokingHoangNvRepo(_context);
            }
        }

        public PlanQuitMethodHoangNvRepo PlanQuitMethodHoangNvRepo
        {
            get
            {
                return _planQuitMethodHoangNvRepo ?? new PlanQuitMethodHoangNvRepo(_context);
            }
        }

        public QuitMethodHoangNvRepo QuitMethodHoangNvRepo
        {
            get
            {
                return _quitMethodHoangNvRepo ?? new QuitMethodHoangNvRepo(_context);
            }
        }

        public RecordProcessHoangNvRepo RecordProcessHoangNv
        {
            get
            {
                return _recordProcessHoangNvRepo ?? new RecordProcessHoangNvRepo(_context);
            }
        }

        public SystemUserRepo UserHoangNvRepo
        {
            get
            {
                return _userHoangNvRepo ?? new SystemUserRepo(_context);
            }
        }



        public int SaveChangeWithTransaction()
        {
            int result = -1;

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
