using NUnit.Framework;
using The.Rules.DescribeRules;
using The.Rules.Tests.Mocks;

namespace The.Rules.Tests.DescribeRules
{
    public class VerboseRuleDescriber
    {
        ARuleAbout<AnyClass> aRuleThatIsTrue;
        ARuleAbout<AnyClass> aRuleThatIsFalse;
        VerboseRuleDescriber<AnyClass> describer;

        [SetUp]
        public void Setup()
        {
            aRuleThatIsTrue = ARuleAbout<AnyClass>.Where(x => true, "Always True");
            aRuleThatIsFalse = ARuleAbout<AnyClass>.Where(x => false, "Always False");
            describer = new VerboseRuleDescriber<AnyClass>();
        }

        [Test]
        public void ARuleCanBeDescribed()
        {
            var description = describer.Describe(aRuleThatIsTrue);
            Assert.That(description, Is.EqualTo("Always True"));
        }

        [Test]
        public void AnAndRuleCanBeDescribed()
        {
            var rule = aRuleThatIsTrue.And(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True AND Always False)"));
        }

        [Test]
        public void AnOrRuleCanBeDescribed()
        {
            var rule = aRuleThatIsTrue.Or(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True OR Always False)"));
        }

        [Test]
        public void AnXorRuleCanBeDescribed()
        {
            var rule = aRuleThatIsTrue.Xor(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True XOR Always False)"));
        }

        [Test]
        public void AnImpliesRuleCanBeDescribed()
        {
            var rule = aRuleThatIsTrue.Implies(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True IMPLIES Always False)"));
        }

        [Test]
        public void APreventsRuleCanBeDescribed()
        {
            var rule = aRuleThatIsTrue.Prevents(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True PREVENTS Always False)"));
        }

        [Test]
        public void ANotRuleCanBeDescribed()
        {
            var rule = aRuleThatIsTrue.Not();

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("NOT Always True"));
        }

        [Test]
        public void RuleDescriptionsIncludeParenthsis()
        {
            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsFalse);
            var anotherAndRule = aRuleThatIsTrue.And(aRuleThatIsTrue);

            var rule = anAndRule.Or(anotherAndRule);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("((Always True AND Always False) OR (Always True AND Always True))"));
        }


        [Test]
        public void NotRuleInRuleTreeIncludesParenthsis()
        {

            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsFalse);
            var notRule = anAndRule.Not();

            var rule = notRule.And(aRuleThatIsTrue);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(NOT (Always True AND Always False) AND Always True)"));
        }

    }
}
