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
    public class TrainingManager
    {
        public List<WordDefinition> GetWordDefinitions(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Training training = uow.TrainingRepository.Find(a => a.UserId == userId).FirstOrDefault();

                if (training.WordDefinition)
                {
                    throw new ValidationException("Već ste trenirali u ovoj kategoriji danas.");
                }
                int count = uow.WordDefinitionRepository.Count();
                List<WordDefinition> words = new List<WordDefinition>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    words.Add(uow.WordDefinitionRepository.GetById(number));
                }
                training.WordDefinition = true;
                uow.Save();

                return words;
            }
        }

        public List<WordSynonym> GetWordSynonyms(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Training training = uow.TrainingRepository.Find(a => a.UserId == userId).FirstOrDefault();

                if (training.WordSynonyms)
                {
                    throw new ValidationException("Već ste trenirali u ovoj kategoriji danas.");
                }

                int count = uow.WordSynonymsRepository.Count();
                List<WordSynonym> words = new List<WordSynonym>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    words.Add(uow.WordSynonymsRepository.GetById(number));
                }

                training.WordSynonyms = true;
                uow.Save();

                return words;
            }
        }

        public List<Calculation> GetCalculations(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Training training = uow.TrainingRepository.Find(a => a.UserId == userId).FirstOrDefault();

                if (training.Calculations)
                {
                    throw new ValidationException("Već ste trenirali u ovoj kategoriji danas.");
                }

                int count = uow.CalculationRepository.Count();
                List<Calculation> calculations = new List<Calculation>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    calculations.Add(uow.CalculationRepository.GetById(number));
                }

                training.Calculations = true;
                uow.Save();

                return calculations;
            }
        }

        public List<GeneralKnowledge> GetGeneralKnowledge(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Training training = uow.TrainingRepository.Find(a => a.UserId == userId).FirstOrDefault();

                if (training.GeneralKnowledge)
                {
                    throw new ValidationException("Već ste trenirali u ovoj kategoriji danas.");
                }

                int count = uow.GeneralKnowledgeRepository.Count();
                List<GeneralKnowledge> generalKnowledge = new List<GeneralKnowledge>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    generalKnowledge.Add(uow.GeneralKnowledgeRepository.GetById(number));
                }

                training.GeneralKnowledge = true;
                uow.Save();

                return generalKnowledge;
            }
        }

        public List<LogicArray> GetLogicArrays(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Training training = uow.TrainingRepository.Find(a => a.UserId == userId).FirstOrDefault();

                if (training.LogicArray)
                {
                    throw new ValidationException("Već ste trenirali u ovoj kategoriji danas.");
                }

                int count = uow.LogicArrayRepository.Count();
                List<LogicArray> logicArrays = new List<LogicArray>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    logicArrays.Add(uow.LogicArrayRepository.GetById(number));
                }

                training.LogicArray = true;
                uow.Save();

                return logicArrays;
            }
        }

        public List<Memory> GetMemory(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Training training = uow.TrainingRepository.Find(a => a.UserId == userId).FirstOrDefault();

                if (training.Memory)
                {
                    throw new ValidationException("Već ste trenirali u ovoj kategoriji danas.");
                }

                int count = uow.MemoryRepository.Count();
                List<Memory> memories = new List<Memory>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    memories.Add(uow.MemoryRepository.GetById(number));
                }

                training.Memory = true;
                uow.Save();

                return memories;
            }
        }

        public List<Projection> GetProjections(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Training training = uow.TrainingRepository.Find(a => a.UserId == userId).FirstOrDefault();

                if (training.Projections)
                {
                    throw new ValidationException("Već ste trenirali u ovoj kategoriji danas.");
                }

                int count = uow.ProjectionRepository.Count();
                List<Projection> projections = new List<Projection>();
                List<int> numbers = GenerateNumbers(count);
                for (int i = 0; i < numbers.Count; i++)
                {
                    int number = numbers[i];
                    projections.Add(uow.ProjectionRepository.GetById(number));
                }

                training.Projections = true;
                uow.Save();

                return projections;
            }
        }

        private List<int> GenerateNumbers(int maxNumber)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 20; i++)
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
    }
}
