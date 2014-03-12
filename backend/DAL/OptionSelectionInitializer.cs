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
            //SeedDummyChoices(context);
        }

        private static void SeedTerms(OptionSelectionContext context)
        {
            var terms = new List<Term>
            {
                new Term{Code=201410,Description="Winter 2014",IsActive=false},
                new Term{Code=201420,Description="Spring/Summer 2014",IsActive=true},
                new Term{Code=201430,Description="Fall 2014",IsActive=false},
                new Term{Code=201510,Description="Winter 2015",IsActive=false},
                new Term{Code=201520,Description="Spring/Summer 2015",IsActive=false}
            };
            terms.ForEach(s => context.Terms.Add(s));
            context.SaveChanges();
        }

        private static void SeedOptions(OptionSelectionContext context)
        {
            var options = new List<Option>
            {
                new Option{OptionID=1,Title="Client Server",IsActive=true},
                new Option{OptionID=2,Title="Data Communications",IsActive=true},
                new Option{OptionID=3,Title="Database",IsActive=false},
                new Option{OptionID=4,Title="Information Systems",IsActive=true}
            };

            options.ForEach(s => context.Options.Add(s));
            context.SaveChanges();
        }

        private static void SeedDummyChoices(OptionSelectionContext context)
        {
            DateTime now = new DateTime();
            var dummyChoices = new List<Choice>
            {
                new Choice{StudentNumber="A00800013",FirstName="Steven",LastName="Hsu",TermCode=201420,FirstOptionChoiceID=4,SecondOptionChoiceID=2,ThirdOptionChoiceID=1,ForthOptionChoiceID=3},
                new Choice{StudentNumber="A00900413",FirstName="Sandy",LastName="Ching",TermCode=201420,FirstOptionChoiceID=2,SecondOptionChoiceID=1,ThirdOptionChoiceID=4,ForthOptionChoiceID=3},
                new Choice{StudentNumber="A01000013",FirstName="Joseph",LastName="Hou",TermCode=201420,FirstOptionChoiceID=1,SecondOptionChoiceID=4,ThirdOptionChoiceID=2,ForthOptionChoiceID=3}
            };
            dummyChoices.ForEach(s => context.Choices.Add(s));
            context.SaveChanges();
        }
    }
}