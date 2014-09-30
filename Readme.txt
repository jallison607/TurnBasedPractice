Turnbased RPG Game Editor(Project Name: AlphaRPG) Readme

-------------------------
Summary:
	The purpose of this project to to provide an Editor in which to create various objects for a turnbased game. Objects such as Items, Weapons, Spells, Enemies, Heros, Classes, Elements, Abilities.
	
	Subpurpose is to provide a platform to test out game balance. (Create a battle between two pre-defined parties using the created items & balance)

-------------------------


Mechanics Index

I. Database Layout
II. Magi System
III. Class System
IV. Combat System
V. Character System
VI. Other potential features

--------------------------
I. Database Layout
	CharacterClass		*Table for various classes (Wizard, Ranger, Knight, Squire.. ect)
		ClassID 		(PRIMARY KEY)
		ClassName		Name of Class
		ConBonus		Bonus to Constitution
		MagBonus		Bonus to Magi
		DexBonus		Bonus to Dexterity
		StrBonus		Bonus to Strength
		SprBonus		Bonus to Spirit
		SpdBonus		Bonus to Speed
		ConPrereq		Class Constitution Prereq
		MagPrereq		Class Magi Prereq
		DexPrereq		Class Dexterity Prereq
		StrPrereq		Class Strength Prereq
		SprPrereq		Class spirit prereq
		SpdPrereq		Class speed prereq
		
	ClassPrereqClasses	*Table of prerequsit Classes & levels to be this class
		autoID			(PRIMARY KEY)
		ClassID			(FORIEGN KEY to PlayerClasses)
		PreReqClassID		(FORIEGN KEY to PlayerClasses)
		PreReqLevel		Level of prereq class required

	ClassElements	*Class & Element link table
		autoID			(PRIMARY KEY)
		ClassID			(FORIGN KEY to PlayerClasses)
		ElementID		(FORIGN KEY to Elements)

	ClassAbilities	*Class & Ability link table
		autoID			(PRIMARY KEY)
		ClassID			(FORIGN KEY to PlayerClasses)
		AbilityID		(FORIGN KEY to Ability)
		LevelLearned	Level that player class learns ability

	Element		*Table of Element
		ElementID		(PRIMARY KEY)
		ElementName		Name of Element
		
	Effect					*Table of Effects
		EffectID				(PRIMARY KEY)
		EffectName				Name of Effect
		ElementType				(FORIGN KEY to Element
		EffectType				Effect Type (increase, decrease, ect...)
		EffectedStat			Stat Effected (HP, Constitution, Speed)
		EffectAmount			Amount to effect the stat
		EffectDuration			Duration of the effect
		
	Ability				*Table of Abilities
		AbilityID			(PRIMARY KEY)
		AbilityName			(Name of Ability)
		
	AbilityEffects		*Ability & Effect Link table
		autoID				(PRIMARY KEY)
		AbilityID			(FORIGN KEY to Ability)
		EffectID			(FORIGN KEY to Effect)
	
	Weapon				*Table of Weapons
		WeaponID			(PRIMARY KEY)
		WeaponName			Name of Weapon
		CanBuy				Weapon can be bought in stores
		WeaponValue			Weapon Value in stores
		WeaponPower			Weapon effectiveness in physical attacks
		WeaponMagiPower			Weapon ability to focus Magical attacks

	WeaponEffects		*Weapon & Effect Link table
		autoID				(PRIMARY KEY)
		WeaponID			(FORIGN KEY to Weapon)
		EffectID			(FORIGN KEY to Effect)
		
	WeaponClasses		*Weapon & Class link table
		autoID				(PRIMARY KEY)
		WeaponID			(FORIGN KEY to Weapon)
		ClassID				(FORIGN KEY to CharacterClass)

	Armor					*Table of Armor
		ArmorID					(PRIMARY KEY)
		ArmorName				Name of Armor
		CanBuy					Armor can be bought in stores
		ArmorValue				Armor Value in stores
		ArmorStrength			Armor Strength vs Physical attacks
		ArmorResistance			Armor Resistance to magical attacks

	Armorclasses		*Armor & Class link table
		autoID				(PRIMARY KEY)
		ArmorID				(FORIGN KEY to Armor)
		ClassID				(FoRIGN KEY to CharacterClass)
		
	Spell				*Table of Spells
		SpellID				(PRIMARY KEY)
		SpellName			Name of Spell
		SpellMagiCost		Magi cost of Spell
		
	SpellEffects		*Spell & Effect link table
		autoID				(PRIMARY KEY)
		SpellID				(FORIGN KEY to Spell)
		EffectID			(FORIGN Key to Effect)
		

--------------------------
II. Magi System

Lore
	Magi is the term refereed to when harnessing the language of the planet. An Ancient language that was used to create the seas, mountains and forests. Mostly forgotten over the millennia. However those brave enough to search can sometimes find fractions of phrases that were used to create the world. Speaking those phrases aloud takes a toll. Draining the essence of life or Magi. Once used adventures must regain their essence of life before being capable of reading additional phrases. Some have found that if you focus on one particular branch of the language you can gain access to much more powerful phrases in that branch. However they found that by focusing on one branch it is very difficult to articulate the words of another branch. Its as if when someone focus on learning the holy branch of the language their essence itself is changed in such a way that it loses its ability to manifest the words of another branch such as time, fire or Ice.
Mechanics
	Characters can cast spells from their spellbook that are in alignment with their permitted elements. Each cast costs Magi points which can be restored via potions and rest.
	
--------------------------
III. Class System
	
	Not yet implemented
	
--------------------------
IV. Combat System
	Key Stats:
		Constitution
			-Used to determine maximum HP
		Strength
			-Used to determine effectiveness at physical attacks
		Spirit
			-Used to determine effectiveness at magic
		Dexterity
			-Used to determine effectiveness at dodging attacks
		Magi
			-Used to determine Maximum MP
		Speed
			-Used to determine speed of attacks (Turn gauge refill rate)
			
	Physical Attacks
		The attacker will roll an attack score based on strength
		The defender will roll evade based on armor.ArmorStrength & dexterity
		If hit the attacker will roll damage based on weapon.WeaponPower
		
	Magical Attacks
		The attacker will roll an attack score based on spirit
		The Defender will roll evade based on armor.ArmorResistance & dexterity
		If hit the attacker will roll damage based on spell & weapon.WeaponMagiPower
	
--------------------------	
V. Character System
	
	Not Yet Implemented

--------------------------
VI. Other potential features
	- Resistance effects
		Example: Armor piece may provide resistance to particular magi elements or a spell may provide temporary resistance to particular elements

	- Status effects
		Example: once your hp = 0 you aquire the status of dead. A particular magi spell may remove the status of Dead and + x HP
		Example 2: Poision & time may be moved to status instead of elements.