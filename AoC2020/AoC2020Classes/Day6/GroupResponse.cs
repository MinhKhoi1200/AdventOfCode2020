using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day6
{
    public class GroupResponse
    {
        public GroupResponse(string rawGroupResponse)
        {
            var delimiter = new string[] {Environment.NewLine};
            var convertedGroupResponseList =
                rawGroupResponse.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToList();

            PersonResponseList =
                convertedGroupResponseList.ConvertAll(eachResponse => new PersonResponse(eachResponse));
        }

        public List<PersonResponse> PersonResponseList { get; }
        public List<char> UniqueYesQuestions => GetUniqueYesQuestionsFromGroupResponse();
        public List<char> CommonYesQuestions => GetCommonYesQuestionsFromGroupResponse();


        private List<char> GetUniqueYesQuestionsFromGroupResponse()
        {
            var allYesQuestions = new List<char>();

            foreach (var personResponse in PersonResponseList)
            {
                allYesQuestions.AddRange(personResponse.YesQuestionsList);
            }

            var uniqueYesQuestions = allYesQuestions.Distinct().ToList();

            return uniqueYesQuestions;
        }

        private List<char> GetCommonYesQuestionsFromGroupResponse()
        {
            var allYesQuestions = new List<char>();

            foreach (var personResponse in PersonResponseList)
            {
                allYesQuestions.AddRange(personResponse.YesQuestionsList);
            }

            var yesQuestionsFrequencyDictionary = new Dictionary<char, int>();

            foreach (var yesQuestion in allYesQuestions)
            {
                if (yesQuestionsFrequencyDictionary.ContainsKey(yesQuestion))
                {
                    yesQuestionsFrequencyDictionary[yesQuestion] += 1;
                }
                else
                {
                    yesQuestionsFrequencyDictionary.Add(yesQuestion, 1);
                }
            }

            return (from questionOccurrence in yesQuestionsFrequencyDictionary
                where questionOccurrence.Value == PersonResponseList.Count
                select questionOccurrence.Key).ToList();
        }

    }
}