using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeletonNET.Portal.Repository.Memory.Database
{
    /// <summary>
    /// In memory database object context.
    /// </summary>
    public class InMemoryDatabaseObjectContext
    {
        /// <summary>
        /// Gets or sets the database customers.
        /// </summary>
        /// <value>
        /// The database customers.
        /// </value>
        public List<DatabaseCustomer> DatabaseCustomers { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static InMemoryDatabaseObjectContext Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryDatabaseObjectContext" /> class.
        /// </summary>
        public InMemoryDatabaseObjectContext()
        {
            InitialiseDatabaseCustomers();
        }

        /// <summary>
        /// Adds the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseEntity">The database entity.</param>
        public void AddEntity<T>(T databaseEntity)
        {
            if (databaseEntity is DatabaseCustomer)
            {
                DatabaseCustomer databaseCustomer = databaseEntity as DatabaseCustomer;
                databaseCustomer.Id = DatabaseCustomers.Count + 1;
                DatabaseCustomers.Add(databaseEntity as DatabaseCustomer);
            }
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseEntity">The database entity.</param>
        public void UpdateEntity<T>(T databaseEntity)
        {
            if (databaseEntity is DatabaseCustomer)
            {
                DatabaseCustomer dbCustomer = databaseEntity as DatabaseCustomer;
                DatabaseCustomer dbCustomerToBeUpdated = (from c in DatabaseCustomers where c.Id == dbCustomer.Id select c).FirstOrDefault();
                dbCustomerToBeUpdated.Address = dbCustomer.Address;
                dbCustomerToBeUpdated.City = dbCustomer.City;
                dbCustomerToBeUpdated.Country = dbCustomer.Country;
                dbCustomerToBeUpdated.CustomerName = dbCustomer.CustomerName;
                dbCustomerToBeUpdated.Telephone = dbCustomer.Telephone;
            }
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseEntity">The database entity.</param>
        public void DeleteEntity<T>(T databaseEntity)
        {
            if (databaseEntity is DatabaseCustomer)
            {
                DatabaseCustomer dbCustomer = databaseEntity as DatabaseCustomer;
                DatabaseCustomer dbCustomerToBeDeleted = (from c in DatabaseCustomers where c.Id == dbCustomer.Id select c).FirstOrDefault();
                DatabaseCustomers.Remove(dbCustomerToBeDeleted);
            }
        }

        /// <summary>
        /// Initialises the database customers.
        /// </summary>
        private void InitialiseDatabaseCustomers()
        {
            DatabaseCustomers = new List<DatabaseCustomer>();
            DatabaseCustomers.Add(new DatabaseCustomer() { Address = "Main street", City = "Birmingham", Country = "UK", CustomerName = "GreatCustomer", Id = 1, Telephone = "N/A" });
            DatabaseCustomers.Add(new DatabaseCustomer() { Address = "Strandvägen", City = "Stockholm", Country = "Sweden", CustomerName = "BadCustomer", Id = 2, Telephone = "123345456" });
            DatabaseCustomers.Add(new DatabaseCustomer() { Address = "Kis utca", City = "Budapest", Country = "Hungary", CustomerName = "FavouriteCustomer", Id = 3, Telephone = "987654312" });
        }

        /// <summary>
        /// Nested class, hold the singleton instance.
        /// </summary>
        private class Nested
        {
            /// <summary>
            /// Initializes the <see cref="Nested"/> class.
            /// </summary>
            static Nested()
            {
            }

            /// <summary>
            /// The instance
            /// </summary>
            internal static readonly InMemoryDatabaseObjectContext instance = new InMemoryDatabaseObjectContext();
        }
    }
}