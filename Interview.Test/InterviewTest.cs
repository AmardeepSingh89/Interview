using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interview.Test
{
    [TestClass]
    public class InterviewTest
    {
        private object expectedResult;

        public Repository<Employee, int> RepositoryDataSet { get; private set; }

        private Employee employee_1, employee_2;

        public void Setup()
        {
            RepositoryDataSet = new Repository<Employee, int>();
            employee_1 = new Employee { ID = 1, Name = "Test_1" };
            employee_1 = new Employee { ID = 2, Name = "Test_2" };
        }

        [TestMethod]
        public void ReturnAllList()
        {
            Assert.IsTrue(expectedResult.GetType() == typeof(List<Employee>));
        }

        [TestMethod]
        public void SaveEmployee()
        {
            RepositoryDataSet.Save(employee_1);
            expectedResult = RepositoryDataSet.GetAll();

            Assert.IsTrue(((IEnumerable<Employee>)expectedResult).Contains(employee_1));
        }

        [TestMethod]
        public void GetEmployee()
        {
            RepositoryDataSet.Save(employee_1);
            RepositoryDataSet.Save(employee_2);

            Assert.AreEqual(employee_1, RepositoryDataSet.Get(1));
            Assert.AreEqual(employee_2, RepositoryDataSet.Get(2));
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            RepositoryDataSet.Save(employee_1);
            RepositoryDataSet.Save(employee_2);

            RepositoryDataSet.Delete(1);

            expectedResult = RepositoryDataSet.GetAll();

            Assert.IsFalse(((IEnumerable<Employee>)expectedResult).Contains(employee_1));
        }
    }
}
