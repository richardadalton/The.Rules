using NUnit.Framework;
using The.Rules.DescribeRules;
using The.Rules.Tests.Mocks;

namespace The.Rules.Tests.DescribeRules
{
    class VerboseEvaluatingRuleDescriber
    {
        ARuleAbout<AnyClass> aRuleThatIsTrue;
        ARuleAbout<AnyClass> aRuleThatIsFalse;
        VerboseEvaluatingRuleDescriber<AnyClass> describer;


        [SetUp]
        public void Setup()
        {
            aRuleThatIsTrue = ARuleAbout<AnyClass>.Where(x => true, "Always True");
            aRuleThatIsFalse = ARuleAbout<AnyClass>.Where(x => false, "Always False");
            describer = new VerboseEvaluatingRuleDescriber<AnyClass>(new AnyClass());
        }

        [Test]
        public void ARuleCanBeEvaluatedAndDescribed()
        {
            var description = describer.Describe(aRuleThatIsTrue);
            Assert.That(description, Is.EqualTo("Always True[T]"));
        }

        [Test]
        public void AnAndRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.And(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True[T] AND Always False[F])[F]"));
        }

        [Test]
        public void AnOrRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Or(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True[T] OR Always False[F])[T]"));
        }

        [Test]
        public void AnXorRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Xor(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True[T] XOR Always False[F])[T]"));
        }

        [Test]
        public void AnImpliesRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Implies(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True[T] IMPLIES Always False[F])[F]"));
        }

        [Test]
        public void APreventsRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Prevents(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True[T] PREVENTS Always False[F])[T]"));
        }

        [Test]
        public void ANotRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Not();

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("NOT (Always True[T])[F]"));
        }

        [Test]
        public void EvaluatedRuleDescriptionsIncludeParenthsis()
        {
            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsFalse);
            var anotherAndRule = aRuleThatIsTrue.And(aRuleThatIsTrue);

            var rule = anAndRule.Or(anotherAndRule);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("((Always True[T] AND Always False[F])[F] OR (Always True[T] AND Always True[T])[T])[T]"));
        }

        [Test]
        public void NotRuleInRuleTreeIncludesParenthsis()
        {

            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsFalse);
            var notRule = anAndRule.Not();

            var rule = notRule.And(aRuleThatIsTrue);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(NOT ((Always True[T] AND Always False[F])[F])[T] AND Always True[T])[T]"));
        }

    }
}
