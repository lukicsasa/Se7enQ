using Se7enQ.Data.Model;
using Se7enQ.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7enQ.Data.UnitOfWork
{
        public class UnitOfWork : IDisposable
        {
            #region Fields

            /// <summary>
            /// Data context
            /// </summary>
            private DbContext context;

            private UserRepository userRepository;

            #endregion Fields

            #region Properties

            /// <summary>
            /// Data context
            /// </summary>
            public DbContext DataContext
            {
                get
                {
                    return context ?? (context = new Se7enQEntities());
                }
            }

            #region Repository


            public UserRepository UserRepository
            {
                get
                {
                    return userRepository ?? (userRepository = new UserRepository(DataContext));
                }
            }


            #endregion Repository

            #endregion Properties

            #region Methods

            /// <summary>
            /// Save changes for unit of work async
            /// </summary>
            public async Task SaveAsync()
            {
                context.ChangeTracker.DetectChanges();
                await context.SaveChangesAsync();
            }

            /// <summary>
            /// Save changes for unit of work
            /// </summary>
            public void Save()
            {
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }

            #endregion Methods

            #region IDisposable Members

            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        if (context != null)
                            context.Dispose();
                    }
                }
                this.disposed = true;
            }

            /// <summary>
            /// Dispose objects
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            #endregion IDisposable Members
        }
}
