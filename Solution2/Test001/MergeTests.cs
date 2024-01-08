using ClassLibrary1;
namespace Test001
{
    [TestClass]
    public class MergeTests
    {

        // 无交叉合并排序测试
        [TestMethod()]
        public void MyMergeTest1()
        {
            Merge aTarget = new Merge();
            int[] a1 = { 1, 3, 5, 7, 9 };
            int[] b1 = { 11, 13, 15, 17, 19 };
            int[] c1 = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            int TestLength = c1.Length;
            int[] L = new int[TestLength];
            aTarget.MyMerge(a1,b1,L);
            for (int i = 0; i < L.Length; i++)
                Assert.AreEqual(L[i], c1[i]);
        }

        // 有交叉合并排序测试
        [TestMethod]
        public void MyMergeTest2()
        {
            Merge aTarget = new Merge();
            int[] a1 = { 1, 3, 5, 7, 9 };
            int[] b1 = { 4, 6, 8, 10, 12 };
            int[] c1 = { 1, 3, 4, 5, 6, 7, 8, 9, 10, 12 };
            int TestLength = c1.Length;
            int[] L = new int[TestLength];
            aTarget.MyMerge(a1, b1, L);
            for (int i = 0; i < L.Length; i++)
                Assert.AreEqual(L[i], c1[i]);
        }

        // 无重复合并排序测试
        [TestMethod]
        public void MyMergeTest3()
        {
            Merge aTarget = new Merge();
            int[] a1 = { 1, 2, 3, 4, 5 };
            int[] b1 = { 6, 7, 8, 9, 10 };
            int[] c1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int TestLength = c1.Length;
            int[] L = new int[TestLength];
            aTarget.MyMerge(a1, b1, L);
            for (int i = 0; i < L.Length; i++)
                Assert.AreEqual(L[i], c1[i]);
        }
        //有重复合并排序测试
        [TestMethod]
        public void MyMergeTest4()
        {
            Merge aTarget = new Merge();
            int[] a1 = { 1, 2, 3, 4, 5 };
            int[] b1 = { 3, 4, 5, 6, 7 };
            int[] c1 = { 1, 2, 3, 3, 4, 4, 5, 5, 6, 7 };
            int TestLength = c1.Length;
            int[] L = new int[TestLength];
            aTarget.MyMerge(a1, b1, L);
            for (int i = 0; i < L.Length; i++)
                Assert.AreEqual(L[i], c1[i]);
        }
    }
}
