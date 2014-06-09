using NUnit.Framework;
using The.Rules.Tests.Mocks;

namespace The.Rules.Tests
{
    public class EvaluateRules
    {
        ARuleAbout<AnyClass> aRuleThatIsTrue;
        ARuleAbout<AnyClass> aRuleThatIsFalse;

        [SetUp]
        public void Setup()
        {
            aRuleThatIsTrue = ARuleAbout<AnyClass>.Where(x => true);
            aRuleThatIsFalse = ARuleAbout<AnyClass>.Where(x => false);
        }

        [Test]
        public void ARuleCanBeTrue()
        {
            Assert.That(aRuleThatIsTrue.IsTrueFor(new AnyClass()));
        }

        [Test]
        public void ARuleCanBeFalse()
        {
            Assert.That(aRuleThatIsFalse.IsFalseFor(new AnyClass()));
        }

        [Test]
        public void RulesCanBeCombinedUsingTheAndOperator()
        {
            Assert.That(aRuleThatIsTrue.And(aRuleThatIsTrue).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsTrue.And(aRuleThatIsFalse).IsFalseFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.And(aRuleThatIsTrue).IsFalseFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.And(aRuleThatIsFalse).IsFalseFor(new AnyClass()));
        }

        [Test]
        public void RulesCanBeCombinedUsingTheOrOperator()
        {
            Assert.That(aRuleThatIsTrue.Or(aRuleThatIsTrue).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsTrue.Or(aRuleThatIsFalse).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Or(aRuleThatIsTrue).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Or(aRuleThatIsFalse).IsFalseFor(new AnyClass()));
        }

        [Test]
        public void RulesCanBeCombinedUsingTheXorOperator()
        {
            Assert.That(aRuleThatIsTrue.Xor(aRuleThatIsTrue).IsFalseFor(new AnyClass()));
            Assert.That(aRuleThatIsTrue.Xor(aRuleThatIsFalse).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Xor(aRuleThatIsTrue).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Xor(aRuleThatIsFalse).IsFalseFor(new AnyClass()));
        }

        [Test]
        public void RulesCanBeCombinedUsingTheImpliesOperator()
        {
            Assert.That(aRuleThatIsTrue.Implies(aRuleThatIsTrue).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsTrue.Implies(aRuleThatIsFalse).IsFalseFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Implies(aRuleThatIsTrue).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Implies(aRuleThatIsFalse).IsTrueFor(new AnyClass()));
        }

        [Test]
        public void RulesCanBeCombinedUsingThePreventsOperator()
        {
            Assert.That(aRuleThatIsTrue.Prevents(aRuleThatIsTrue).IsFalseFor(new AnyClass()));
            Assert.That(aRuleThatIsTrue.Prevents(aRuleThatIsFalse).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Prevents(aRuleThatIsTrue).IsTrueFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Prevents(aRuleThatIsFalse).IsTrueFor(new AnyClass()));
        }


        [Test]
        public void ARuleCanBeNegatedUsingTheNotOperator()
        {
            Assert.That(aRuleThatIsTrue.Not().IsFalseFor(new AnyClass()));
            Assert.That(aRuleThatIsFalse.Not().IsTrueFor(new AnyClass()));
        }
    }
}
