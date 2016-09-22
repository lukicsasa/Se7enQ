using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Se7enQ.Entities;
using Se7enQ.Data.UnitOfWork;
using Se7enQ.Common.Exceptions;

namespace Se7enQ.Core
{
    public class GameManager
    {
        public User FindOpponent(int currentUserId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                User currentUser = uow.UserRepository.GetById(currentUserId);

                while (true)
                {
                    var game = uow.GameRepository.Find(a => a.SecondPlayerId == null).FirstOrDefault();
                    if (game != null)
                    {
                        game.SecondPlayerId = currentUserId;
                        game.GameQuestion = GenerateQuestions();
                        uow.Save();

                        return uow.UserRepository.Find(a => a.Id == game.FirstPlayerId).FirstOrDefault();
                    }
                    else
                    {
                        uow.GameRepository.Insert(new Game
                        {
                            FirstPlayerId = currentUserId,
                            DatePlayed = DateTime.UtcNow
                        });
                        uow.Save();
                        while (true)
                        {
                            var secondPlayer = GetSecondPlayer(currentUserId);
                            if (secondPlayer != null)
                            {
                                return secondPlayer;
                            }

                        }
                    }
                }
            }
        }

        public object GetQuestion(int currentUserId, string answer, bool correct, int questionIndex)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                string opponentAnswer = null;
                int opponentPoints = 0;
                Game game = uow.GameRepository.Find(a => a.FirstPlayerId == currentUserId || a.SecondPlayerId == currentUserId).FirstOrDefault();

                if (questionIndex == 20)
                {
                    if (game != null)
                    {
                        var generatedQuestions = uow.GameQuestionsRepository.Find(a => a.Id == game.GameQuestions).FirstOrDefault();

                        int firstPlayerPoints = (int)game.FirstPlayerPoints;
                        int secondPlayerPoins = (int)game.SecondPlayerPoints;

                        uow.GameRepository.Delete(game);
                        uow.GameQuestionsRepository.Delete(generatedQuestions);
                        uow.Save();

                        if(game.FirstPlayerId == currentUserId)
                        {
                            return new
                            {
                                opponentPoints = secondPlayerPoins,
                                playerPoints = firstPlayerPoints
                            };
                        }
                        else
                        {
                            return new
                            {
                                opponentPoints = firstPlayerPoints,
                                playerPoints = secondPlayerPoins
                            };
                        }
                        
                    }
                    else
                    {
                        return null;
                    }
                }

                if (game.FirstPlayerId == currentUserId)
                {
                    game.FirstPlayerAnswer = answer;
                    if (correct)
                    {
                        game.FirstPlayerPoints++;
                    }
                    uow.Save();
                     while (true)
                    {
                        dynamic opponentScore = GetOpponentScore(1, game.Id);
                        if (opponentScore != null)
                        {
                            opponentAnswer = opponentScore.Answer;
                            opponentPoints = (int)opponentScore.Points;
                            break;
                        }
                    }
                }
                else
                {
                    game.SecondPlayerAnswer = answer;
                    if (correct)
                    {
                        game.SecondPlayerPoints++;
                    }
                    uow.Save();
                    while (true)
                    {
                        dynamic opponentScore = GetOpponentScore(2, game.Id);
                        if (opponentScore != null)
                        {
                            opponentAnswer = opponentScore.Answer;
                            opponentPoints = (int)opponentScore.Points;
                            break;
                        }
                    }
                }

                GameQuestion questions = uow.GameQuestionsRepository.Find(a => a.Id == game.GameQuestions).FirstOrDefault();
                var nextQuestion = GetQuestion(questions, questionIndex);
                return new
                {
                    question = nextQuestion,
                    opponentAnswer = opponentAnswer,
                    opponentPoints = opponentPoints,
                    playerPoints = game.FirstPlayerPoints
                };
            }
        }

        private object GetOpponentScore(int player, int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Game game = uow.GameRepository.Find(a => a.Id == id).FirstOrDefault();
                if (player == 1)
                {
                    if (game.SecondPlayerAnswer != null)
                    {
                        object answer = new
                        {
                            Answer = game.SecondPlayerAnswer,
                            Points = game.SecondPlayerPoints
                        };
                        game.FirstPlayerAnswer = null;
                        game.SecondPlayerAnswer = null;
                        uow.Save();
                        return answer;
                    }
                }
                else
                {
                    if (game.FirstPlayerAnswer != null)
                    {
                        object answer = new
                        {
                            Answer = game.FirstPlayerAnswer,
                            Points = game.FirstPlayerPoints
                        };
                        game.FirstPlayerAnswer = null;
                        game.SecondPlayerAnswer = null;
                        uow.Save();
                        return answer;
                    }
                }

                return null;
            }
        }

        private User GetSecondPlayer(int firstPlayerId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var player2Id = uow.GameRepository.Find(a => a.FirstPlayerId == firstPlayerId && a.SecondPlayerId != null).FirstOrDefault()?.SecondPlayerId;

                return uow.UserRepository.Find(a => a.Id == player2Id.Value).FirstOrDefault();
            }
        }

        private GameQuestion GenerateQuestions()
        {
            List<WordSynonym> synonyms = GetWordSynonyms();
            List<WordDefinition> definitions = GetWordDefinitions();
            List<LogicArray> logicArrays = GetLogicArrays();
            List<Calculation> calculations = GetCalculations();
            List<GeneralKnowledge> generalKnowledge = GetGeneralKnowledge();

            GameQuestion questions = new GameQuestion
            {
                WordSynonyms1 = synonyms[0].Id,
                WordSynonyms2 = synonyms[1].Id,
                WordSynonyms3 = synonyms[2].Id,
                WordSynonyms4 = synonyms[3].Id,
                WordDefinitions1 = definitions[0].Id,
                WordDefinitions2 = definitions[1].Id,
                WordDefinitions3 = definitions[2].Id,
                WordDefinitions4 = definitions[3].Id,
                LogicArray1 = logicArrays[0].Id,
                LogicArray2 = logicArrays[1].Id,
                LogicArray3 = logicArrays[2].Id,
                LogicArray4 = logicArrays[3].Id,
                Calculations1 = calculations[0].Id,
                Calculations2 = calculations[1].Id,
                Calculations3 = calculations[2].Id,
                Calculations4 = calculations[3].Id,
                GeneralKnowledge1 = generalKnowledge[0].Id,
                GeneralKnowledge2 = generalKnowledge[1].Id,
                GeneralKnowledge3 = generalKnowledge[2].Id,
                GeneralKnowledge4 = generalKnowledge[3].Id
            };
            return questions;
        }

        public List<WordDefinition> GetWordDefinitions()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                int count = uow.WordDefinitionRepository.Count();
                List<WordDefinition> words = new List<WordDefinition>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    words.Add(uow.WordDefinitionRepository.GetById(number));
                }

                return words;
            }
        }

        public List<WordSynonym> GetWordSynonyms()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                int count = uow.WordSynonymsRepository.Count();
                List<WordSynonym> words = new List<WordSynonym>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    words.Add(uow.WordSynonymsRepository.GetById(number));
                }

                return words;
            }
        }

        public List<Calculation> GetCalculations()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                int count = uow.CalculationRepository.Count();
                List<Calculation> calculations = new List<Calculation>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    calculations.Add(uow.CalculationRepository.GetById(number));
                }

                return calculations;
            }
        }

        public List<GeneralKnowledge> GetGeneralKnowledge()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                int count = uow.GeneralKnowledgeRepository.Count();
                List<GeneralKnowledge> generalKnowledge = new List<GeneralKnowledge>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    generalKnowledge.Add(uow.GeneralKnowledgeRepository.GetById(number));
                }

                return generalKnowledge;
            }
        }

        public List<LogicArray> GetLogicArrays()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                int count = uow.LogicArrayRepository.Count();
                List<LogicArray> logicArrays = new List<LogicArray>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    logicArrays.Add(uow.LogicArrayRepository.GetById(number));
                }

                return logicArrays;
            }
        }

        public List<Memory> GetMemory()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                int count = uow.MemoryRepository.Count();
                List<Memory> memories = new List<Memory>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    memories.Add(uow.MemoryRepository.GetById(number));
                }

                return memories;
            }
        }

        public List<Projection> GetProjections()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                int count = uow.ProjectionRepository.Count();
                List<Projection> projections = new List<Projection>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    projections.Add(uow.ProjectionRepository.GetById(number));
                }

                return projections;
            }
        }

        private List<int> GenerateNumbers(int maxNumber)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    Random rand = new Random();
                    int randomNumber = rand.Next(1, maxNumber);
                    if (!numbers.Contains(randomNumber))
                    {
                        numbers.Add(randomNumber);
                        break;
                    }
                }
            }
            return numbers;
        }

        private object GetQuestion(GameQuestion questions, int questionIndex)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                switch (questionIndex)
                {
                    case 0: return uow.WordSynonymsRepository.GetById(questions.WordSynonyms1);
                    case 1: return uow.WordSynonymsRepository.GetById(questions.WordSynonyms2);
                    case 2: return uow.WordSynonymsRepository.GetById(questions.WordSynonyms3);
                    case 3: return uow.WordSynonymsRepository.GetById(questions.WordSynonyms4);
                    case 4: return uow.WordDefinitionRepository.GetById(questions.WordDefinitions1);
                    case 5: return uow.WordDefinitionRepository.GetById(questions.WordDefinitions2);
                    case 6: return uow.WordDefinitionRepository.GetById(questions.WordDefinitions3);
                    case 7: return uow.WordDefinitionRepository.GetById(questions.WordDefinitions4);
                    case 8: return uow.LogicArrayRepository.GetById(questions.LogicArray1);
                    case 9: return uow.LogicArrayRepository.GetById(questions.LogicArray2);
                    case 10: return uow.LogicArrayRepository.GetById(questions.LogicArray3);
                    case 11: return uow.LogicArrayRepository.GetById(questions.LogicArray4);
                    case 12: return uow.CalculationRepository.GetById(questions.Calculations1);
                    case 13: return uow.CalculationRepository.GetById(questions.Calculations2);
                    case 14: return uow.CalculationRepository.GetById(questions.Calculations3);
                    case 15: return uow.CalculationRepository.GetById(questions.Calculations4);
                    case 16: return uow.GeneralKnowledgeRepository.GetById(questions.GeneralKnowledge1);
                    case 17: return uow.GeneralKnowledgeRepository.GetById(questions.GeneralKnowledge2);
                    case 18: return uow.GeneralKnowledgeRepository.GetById(questions.GeneralKnowledge3);
                    case 19: return uow.GeneralKnowledgeRepository.GetById(questions.GeneralKnowledge4);
                    default: return null;
                }
            }
        }
    }
}
