﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareHead.SequenceGenerators
{
	public class PairedWordsSequenceGenerator : ISequenceGenerator
	{
		public Sequence Generate(int numberOfItems)
		{
			var sequence = new Sequence {FirstItem = null};
			var words = GetWords();
			var rand = new Random();
			var lowerBand = 0;
			var upperBand = words.Count;

			for (var i = 1; i < numberOfItems + 1; i += 2)
			{
				string value;
				do
				{
					value = words[rand.Next(lowerBand, upperBand)];
				} while (sequence.Items.Exists(item => item.Value == value));

				sequence.Items.Add(new SequenceItem {Value = value, NextItem = i + 1});
				sequence.Items.Add(new SequenceItem {Value = value, NextItem = i});
			}

			return sequence;
		}

		private List<string> GetWords()
		{
			return
				"Abilities,Accommodation,Activity,Adolescence,Adoption,Adult,Advice,Advise,Affection,Affinity,Alimony,Allegiance,Ancestor,Anger,Anniversary,Antagonism,Anxiety,Appreciation,Approval,Ardent,Association,Attentive,Aunt,Authority,Bachelor,Banns,Baptism,Bar mitzvah, Bat mitzvah,Betroth,Bloodline,Bonds,Bone fide, Breadwinner, Bride, Brotherly, Care, Care-giver,Celibate,Cherish,Child,Childhood,Children,Chores,Civility,Clan,Close - knit,Coaching,Cohort,Comfortable,Commitment,Commonality,Communicative,Community,Compassion,Compatibility,Competitive,Concern,Confidence,Congenial,Conjugal,Connection,Consideration,Constancy,Convivial,Couple,Courteous,Cousin,Custody,Daughter,Death,Decency,Defend,Deferential,Dependable,Descent,Determination,Development,Devotion,Differences,Discipline,Distance,Distant,Diverse,Divorce,Dowry,Dynamics,Earnest,Elderly,Eligible,Emotional,Empathy,Encouragement,Endearing,Engaged,Esteem,Estrangement,Everlasting,Fair,Faithful,Family,Father,Favoritism,Feelings,Fidelity,Flexibility,Folks,Forebear,Forgiveness,Foster child, Foundation, Fraternal, Fraternal, Fretful, Friends, Friendship, Genealogy, Generation, Generosity, Genes, Genuine, Geriatric, Gestation, Grandparent, Grateful, Gratitude, Groom, Group, Grownup, Guardian, Guidance, Healthy, Heir, Helpmate, Hereditary, Heritage, History, Honesty, Hopeful, Hostility, House guest,Humor,Husband,Idealism,Illness,In - law,Indifference,Industrious,Infancy,Inheritance,Inspiration,Instructive,Insulting,Integrity,Intuitive,Isolation,Jealousy,Jobs,Joy,Judgment,Jurisdiction,Just,Juvenile,Kin,Kindness,Kindred,Kinfolk,Kinship,Laughter,Legal,Lineage,Listener,Longevity,Loving,Loyalty,Maiden name, Majority, Marriage, Mate, Matriarch, Matrimony, Mature, Maturity, Memories, Mentoring, Minor, Mom, Monogamy, Morale, Morals, Mother, Natal, Neglectful, Nephew, Nest, Newlywed, Niece, Nuclear family,Nuisance,Nuptial,Nurture,Obedient,Obnoxious,Observant,Offspring,Open - minded,Optimism,Origin,Parent,Partiality,Partner,Paternity,Patience,Patriarch,People,Perceptive,Perseverance,Philosophic,Polite,Posterity,Pretentious,Principles,Progeny,Protection,Provider,Punishment,Quality,Quantity,Quiet,Race,Relation,Relationship,Reliability,Reliance,Religion,Resilience,Resolution of differences,Respect,Respect,Responsibility,Retirement,Safety,Security,Senior,Sensible,Sensitivity,Separation,Sharing,Shivaree,Sibling,Sickness,Similarities,Sincerity,Single,Sister,Sisterhood,Solidarity,Son,Soul mate, Spouse, Standard, Stepmother, Support, Surname, Sweet, Sympathetic, Tact, Teamwork, Tenderness, Thoughtfulness, Ties, Time together,Tolerant,Tradition,Trait,Tribe,Triplet.troth,Trust,Trustworthy,Truthful,Twin,Uncle,Understanding,Unforgiving,Union,Unique,Unite,Unity,Upbringing,Vacation,Valuable,Values,Variety,Vigilance,Volunteer,Vow,Warmth,Watchful,Wedlock,Welcoming,Wife,Willingness,Wisdom,Wise,Work,Worry,Worthwhile,Worthy,Youngster,Youth,Zea"
					.Split(',')
					.ToList();
		}
	}
}