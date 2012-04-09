namespace TestRepository
{
    using System.Linq;

    partial class TestDataRepositoryDataContext
    {
        public void ClearData()
        {
            var data = from d in TestDatas select d;

            TestDatas.DeleteAllOnSubmit(data);

            SubmitChanges();
        }

    }
}
