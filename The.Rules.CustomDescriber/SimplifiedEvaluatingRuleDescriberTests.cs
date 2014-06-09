using NUnit.Framework;
using The.Rules.Tests.Mocks;

namespace The.Rules.CustomDescriber
{
    class SimplifiedEvaluatingRuleDescriber
    {
        ARuleAbout<AnyClass> aRuleThatIsTrue;
        ARuleAbout<AnyClass> aRuleThatIsFalse;
        SimplifiedEvaluatingRuleDescriber<AnyClass> describer;


        [SetUp]
        public void Setup()
        {
            aRuleThatIsTrue = ARuleAbout<AnyClass>.Where(x => true, "Always True");
            aRuleThatIsFalse = ARuleAbout<AnyClass>.Where(x => false, "Always False");
            describer = new SimplifiedEvaluatingRuleDescriber<AnyClass>(new AnyClass());
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
            Assert.That(description, Is.EqualTo("Always True[T] AND[F] Always False[F]"));
        }

        [Test]
        public void AnOrRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Or(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("Always True[T] OR[T] Always False[F]"));
        }

        [Test]
        public void AnXorRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Xor(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("Always True[T] XOR[T] Always False[F]"));
        }

        [Test]
        public void AnImpliesRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Implies(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("Always True[T] IMPLIES[F] Always False[F]"));
        }

        [Test]
        public void APreventsRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Prevents(aRuleThatIsFalse);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("Always True[T] PREVENTS[T] Always False[F]"));
        }

        [Test]
        public void ANotRuleCanBeEvaluatedAndDescribed()
        {
            var rule = aRuleThatIsTrue.Not();

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("NOT[F] Always True[T]"));
        }

        [Test]
        public void EvaluatedRuleDescriptionsIncludeParenthsis()
        {
            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsFalse);
            var anotherAndRule = aRuleThatIsTrue.And(aRuleThatIsTrue);

            var rule = anAndRule.Or(anotherAndRule);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(Always True[T] AND[F] Always False[F]) OR[T] (Always True[T] AND[T] Always True[T])"));
        }

        [Test]
        public void NotRuleInRuleTreeIncludesParenthsis()
        {
            var anAndRule = aRuleThatIsTrue.And(aRuleThatIsFalse);
            var notRule = anAndRule.Not();

            var rule = notRule.And(aRuleThatIsTrue);

            var description = describer.Describe(rule);
            Assert.That(description, Is.EqualTo("(NOT[T] (Always True[T] AND[F] Always False[F])) AND[T] Always True[T]"));
        }

    }
}
