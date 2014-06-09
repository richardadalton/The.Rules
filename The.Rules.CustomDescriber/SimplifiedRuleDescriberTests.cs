using NUnit.Framework;
using The.Rules.Tests.Mocks;

namespace The.Rules.CustomDescriber
{
    class SimplifiedRuleDescriberTests
    {
        ARuleAbout<AnyClass> aRuleThatIsTrue;
        ARuleAbout<AnyClass> aRuleThatIsFalse;
        SimplifiedRuleDescriber<AnyClass> describer;

        [SetUp]
        public void Setup()
        {
            aRuleThatIsTrue = ARuleAbout<AnyClass>.Where(x => true, "Always True");
            aRuleThatIsFalse = ARuleAbout<AnyClass>.Where(x => false, "Always False");
            describer = new SimplifiedRuleDescriber<AnyClass>();
        }

        [Test]
        public void UnneededParenthesisAreNotShown()
        {
            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsFalse);
            var anotherAndRule = aRuleThatIsTrue.And(aRuleThatIsTrue);

            var rule = anAndRule.And(anotherAndRule);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("Always True AND Always False AND Always True AND Always True"));
        }

        [Test]
        public void NeededParenthesisForOrAreIncluded()
        {
            var anOrRule = aRuleThatIsTrue.Or(aRuleThatIsFalse);
            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsTrue);

            var rule = anOrRule.And(anAndRule);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True OR Always False) AND Always True AND Always True"));
        }

        [Test]
        public void NeededParenthesisForAndAreIncluded()
        {
            var anOrRule = aRuleThatIsTrue.Or(aRuleThatIsFalse);
            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsTrue);

            var rule = anOrRule.Or(anAndRule);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("Always True OR Always False OR (Always True AND Always True)"));
        }

    }
}
