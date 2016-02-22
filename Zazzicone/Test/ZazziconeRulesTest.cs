using System;
using System.Collections.Generic;
using System.Linq;
using Launcher;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class ZazziconeRulesTest
    {
        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public void Straight(IEnumerable<int> diceValues, int sequenceSize, int scores)
        {
            var smallStraightRule = new ZazziconeStraightDiceRule(sequenceSize, scores);

            var actual = smallStraightRule.Apply(diceValues);

            Assert.AreEqual(scores, actual);
        }

        public static IEnumerable<TestCaseData> GetTestCases()
        {
            yield return new TestCaseData(new[] { 0, 1, 2, 3, 4 }, 4, 30) { TestName = "Small" };
            yield return new TestCaseData(new[] { 0, 2, 3, 4, 5 }, 4, 30) { TestName = "Small" };
            yield return new TestCaseData(new[] { 0, 3, 4, 5, 6 }, 4, 30) { TestName = "Small" };
            yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }, 4, 30) { TestName = "Small" };
            yield return new TestCaseData(new[] { 1, 0, 3, 4, 5 }, 4, 0) { TestName = "Small" };

            yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }, 5, 40) { TestName = "Large" };
            yield return new TestCaseData(new[] { 2, 3, 4, 5, 6 }, 5, 40) { TestName = "Large" };
            yield return new TestCaseData(new[] { 0, 2, 3, 4, 5 }, 5, 0) { TestName = "Large" };
            yield return new TestCaseData(new[] { 1, 2, 3, 4, 0 }, 5, 0) { TestName = "Large" };

            yield return new TestCaseData(new[] { 6, 7, 8, 9, 10 }, 5, 40) { TestName = "Large" };

            var sequence = Enumerable.Range(23, 17).Union(new[] { 3, 5, 8, 13 }).OrderBy(i => Guid.NewGuid());
            
            yield return new TestCaseData(sequence, 16, 100) { TestName = "Random" };
            yield return new TestCaseData(sequence, 17, 100) { TestName = "Random" };
            yield return new TestCaseData(sequence, 18, 0) { TestName = "Random" };
        }
    }
}
