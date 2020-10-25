using ICUScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Services
{
    public class InMemoryHighscoreTable
    {
        List<HighScore> highScores;
        public InMemoryHighscoreTable()
        {
            highScores = new List<HighScore> { new HighScore {ID=0,pID=1,gID=1,Highscore=999,LastEmailed=null,LastUpdated=DateTime.Now},
            new HighScore {ID=1,pID=2,gID=3,Highscore=100,LastEmailed=null,LastUpdated=DateTime.Now }
            };
        }

        public IEnumerable<HighScore> GetAll()
        {
            return highScores.OrderByDescending(s => s.Highscore);
        }

        public HighScore GetScore(HighScore newScore)
        {
            HighScore currentScore = new HighScore();
            currentScore = highScores.Where(h => h.pID == newScore.pID && h.gID == newScore.gID).FirstOrDefault();
            return currentScore;
        }

        public void UpdateScore(HighScore newHighscore)
        {
            HighScore currentHS = highScores.Where(h => h.pID == newHighscore.pID && h.gID == newHighscore.gID).FirstOrDefault();
            currentHS.Highscore = newHighscore.Highscore;
            currentHS.LastUpdated = DateTime.Now;
        }

        public void AddScore(HighScore highScore)
        {
            highScores.Add(highScore);
            //in memory db
            highScore.ID = highScores.Max(h => h.ID) + 1;
        }
    }
}
