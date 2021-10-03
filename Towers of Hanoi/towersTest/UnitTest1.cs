using towers;
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace towersTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestIsLoop()
        {
            var s = new State();
            var s2 = new State(s);
            s2.DiscPositions[0] = 1;
            var s3 = new State(s2);
            s3.DiscPositions[0] = 0;

            Assert.False(Solver.IsLoop(s));
            Assert.False(Solver.IsLoop(s2));
            Assert.True(Solver.IsLoop(s3));
        }

        [Theory]
        [MemberData(nameof(GetNeighboursTestData))]
        public void TestGetNeighbours(int[] discPositions, List<int[]> neighboursDiscPositions)
        {
            var s = new State { DiscPositions = discPositions};

            var result = Solver.GetNeighbours(s).ToList();

            Assert.Equal(neighboursDiscPositions.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Contains(neighboursDiscPositions, x => result[i].DiscPositions.SequenceEqual(x));
            }
        }
         
        public static IEnumerable<object[]> GetNeighboursTestData()
        {
            yield return new object[] { new int[] { 0, 0, 0 }, new List<int[]> { new int[] { 1, 0, 0 }, new int[] { 2, 0, 0 } } };
            yield return new object[] { new int[] { 1, 0, 2 }, new List<int[]> { new int[] { 1, 2, 2 }, new int[] { 2, 0, 2 }, new int[] { 0, 0, 2 }} };
            yield return new object[] { new int[] { 2, 0, 0 }, new List<int[]> { new int[] { 2, 1, 0 }, new int[] { 0, 0, 0 }, new int[] { 1, 0, 0} } };


        }
    }
}
 