using backend.Models;
using backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.DAL
{
    public class OptionSelectionInitializer : System.Data.Entity.DropCreateDatabaseAlways<OptionSelectionContext>
    {
        protected override void Seed(OptionSelectionContext context)
        {
            SeedOptions(context);
            SeedTerms(context);
            SeedDummyChoices(context);
        }

        private static void SeedTerms(OptionSelectionContext context)
        {
            var terms = new List<Term>
            {
                new Term{Id=201410,Description="Winter 2014",IsActive=false},
                new Term{Id=201420,Description="Spring/Summer 2014",IsActive=true},
                new Term{Id=201430,Description="Fall 2014",IsActive=false},
                new Term{Id=201510,Description="Winter 2015",IsActive=false},
                new Term{Id=201520,Description="Spring/Summer 2015",IsActive=false}
            };
            terms.ForEach(s => context.Terms.Add(s));
            context.SaveChanges();
        }

        private static void SeedOptions(OptionSelectionContext context)
        {
            var options = new List<Option>
            {
                new Option{Id=1,Title="Client Server",IsActive=true},
                new Option{Id=2,Title="Data Communications",IsActive=true},
                new Option{Id=3,Title="Database",IsActive=false},
                new Option{Id=4,Title="Information Systems",IsActive=true}
            };

            options.ForEach(s => context.Options.Add(s));
            context.SaveChanges();
        }

        private static void SeedDummyChoices(OptionSelectionContext context)
        {
            DateTime now = new DateTime();
            var dummyChoices = new List<Choice>
            {
                new Choice{StudentNumber="A00800013",FirstName="Steven",LastName="Hsu",TermId=201420,FirstOptionChoiceId=4,SecondOptionChoiceId=2,ThirdOptionChoiceId=1,ForthOptionChoiceId=3},
                new Choice{StudentNumber="A00900413",FirstName="Sandy",LastName="Ching",TermId=201420,FirstOptionChoiceId=2,SecondOptionChoiceId=1,ThirdOptionChoiceId=4,ForthOptionChoiceId=3},
                new Choice{StudentNumber="A01000013",FirstName="Joseph",LastName="Hou",TermId=201420,FirstOptionChoiceId=1,SecondOptionChoiceId=4,ThirdOptionChoiceId=2,ForthOptionChoiceId=3}
            };
            dummyChoices.ForEach(s => context.Choices.Add(s));
            context.SaveChanges();
        }
    }
}