using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareHead.SequenceGenerators
{
	public class PairedWordsSequenceGenerator : ISequenceGenerator
	{
		public Sequence Generate(int numberOfItems)
		{
			var sequence = new Sequence {FirstItem = null};

			for (var i = 1; i < numberOfItems + 1; i += 2)
			{
				string word = GetWordNotInSequence(sequence);

				sequence.Items.Add(new SequenceItem { Value = word, NextItem = i + 1 });
				sequence.Items.Add(new SequenceItem { Value = word, NextItem = i });
			}

			return sequence;
		}

		private string GetWordNotInSequence(Sequence sequence)
		{
			var words = GetWords();

			var lowerBand = 0;
			var upperBand = words.Count;
			var rand = new Random();

			string word;
			do
			{
				word = words[rand.Next(lowerBand, upperBand)];
			} while (sequence.Items.Exists(item => item.Value == word));
			return word;
		}

		private List<string> GetWords()
		{
			return
				"jazz,buzz,fuzz,fizz,hajj,juju,quiz,razz,jeez,jeux,jinx,jock,jack,jump,jamb,juku,joky,jivy,jiff,junk,jimp,jibb,jauk,phiz,zouk,zonk,juke,chez,cozy,zyme,mazy,jouk,qoph,jink,whiz,fozy,joke,jake,zebu,java,fuji,jowl,puja,jerk,jaup,jive,jagg,zeks,jupe,fuze,putz,hazy,koji,zinc,futz,juba,zerk,juco,jube,quip,waxy,jehu,bozo,mozo,jugs,jows,jeep,dozy,lazy,jefe,flux,maze,czar,faze,pixy,meze,john,boxy,jibe,juga,jibs,bize,jury,jobs,prez,jabs,friz,jape,poxy,zeps,jams,quay,zany,yutz,zaps,quey,zarf,mojo,quag,hadj"
					.Split(',')
					.ToList();
		}
	}
}