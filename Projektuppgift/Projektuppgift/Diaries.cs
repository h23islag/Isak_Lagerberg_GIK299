using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    internal class Diaries
    {
        private List<Diary> diaryList;

        public Diaries()
        {
            this.diaryList = new List<Diary>();
        }

        public void CreateDiary(User user)
        {
            Diary diary = new Diary();
            Console.WriteLine();
            Typewriter.TypewriterEffect("Ange en titel på dagboken: ", false);
            diary.SetTitle(Console.ReadLine());
            Console.WriteLine();
            diary.SetOwner(user.GetUsername());
            AddDiary(diary);
            Typewriter.TypewriterEffect($"Dagbok med titeln \"{diary.GetTitle()}\" skapad!");
        }
        public void AddDiary(Diary diary)
        {
            this.diaryList.Add(diary);
        }

        public void RemoveDiary(string diary)
        {
            // Create a copy of the diaryList to iterate over
            List<Diary> diariesToRemove = new List<Diary>(this.diaryList);

            // Iterate over the copy and remove matching diaries from the original list
            foreach (Diary d in diariesToRemove)
            {
                if (d.GetTitle() == diary)
                {
                    this.diaryList.Remove(d);
                }
            }
        }

        public void ListDiaries()
        {
            if(this.diaryList.Count == 0)
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("Finns ingen dagbok kopplat till denna användare!");
                return;
            }
            foreach(Diary diary in this.diaryList) 
            {
                Typewriter.TypewriterEffect("* " + diary.GetTitle());
            }
        }

        public List<Diary> GetDiaryList()
        {
            return this.diaryList;
        }

        public Diary GetDiary(string title)
        {
            foreach (Diary diary in diaryList)
            {
                if(diary.GetTitle() == title)
                {
                    diary.UpdateDate();
                    return diary;
                }
            }
            Console.WriteLine();
            Typewriter.TypewriterEffect($"Kunde inte hitta dagbok med namnet: {title}", false);
            return null;
        }
    }
}
