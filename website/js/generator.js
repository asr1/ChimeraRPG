	//Global Lists
	var words;
 	var places = ["Apple",
				"Autumn",
				"Babbler",
				"Back",
				"Band",
				"Bane",
				"Bang",
				"Bark",
				"Bay",
				"Beak",
				"Beam",
				"Bean",
				"Bell",
				"Bend",
				"Bird",
				"Birth",
				"Bite",
				"Black",
				"Blade",
				"Blast",
				"Blaster",
				"Blood",
				"Blue",
				"Blunder",
				"Board",
				"Boat",
				"Bolt",
				"Bolt",
				"Bone",
				"Born",
				"Break",
				"Briar",
				"Brisk",
				"Buck",
				"Bump",
				"Bunker",
				"Burn",
				"Burst",
				"Cap",
				"Chain",
				"Chander",
				"Chill",
				"Chime",
				"Chowder",
				"Chunder",
				"Clash",
				"Coal",
				"Com",
				"Crack",
				"Crash",
				"Crest",
				"Crimson",
				"Cross",
				"Crow",
				"Dark",
				"Dark",
				"Dawn",
				"Death",
				"Deep",
				"Dent",
				"Dome",
				"Doom",
				"Down",
				"Drain",
				"Dread",
				"Drive",
				"Dwarf",
				"Ear",
				"Elder",
				"Eve",
				"Ever",
				"Eyes",
				"Fall",
				"Fire",
				"Flab",
				"Flash",
				"Flip",
				"Fluid",
				"Folly",
				"Foot",
				"Fort",
				"Fox",
				"Free",
				"Frost",
				"Fruit",
				"Gate",
				"Glade",
				"Glass",
				"Glen",
				"Glory",
				"Golden",
				"Grab",
				"Grass",
				"Greed",
				"Green",
				"Grey",
				"Grid",
				"Ground",
				"Grove",
				"Growth",
				"Guard",
				"Hack",
				"Hallow",
				"Harvest",
				"Haven",
				"Hawk",
				"Hill",
				"Hole",
				"Hollow",
				"Horn",
				"House",
				"Hydra",
				"Ice",
				"Idle",
				"Jest",
				"Jolt",
				"Jump",
				"Keep",
				"Kill",
				"Knell",
				"Knight",
				"Knot",
				"Lake",
				"Lance",
				"Launch",
				"Lens",
				"Light",
				"Log",
				"Loop",
				"Maker",
				"March",
				"Mark",
				"Mirth",
				"Mist",
				"Musket",
				"Nail",
				"Need",
				"News",
				"Night",
				"Out",
				"Pasture",
				"Path",
				"Plant",
				"Port",
				"Pot",
				"Power",
				"Pressure",
				"Project",
				"Query",
				"Quest",
				"Quick",
				"Quip",
				"Rake",
				"Raven",
				"Red",
				"Regret",
				"Rend",
				"Render",
				"Ring",
				"Rock",
				"Rod",
				"Roll",
				"Roll",
				"Rumble",
				"Runner",
				"Sanctuary",
				"Seat",
				"Secret",
				"Seed",
				"Sentinel",
				"Shack",
				"Shade",
				"Shale",
				"Shallow",
				"Shame",
				"Shard",
				"Shave",
				"Shaven",
				"Shed",
				"Ship",
				"Short",
				"Short",
				"Shot",
				"Shutter",
				"Silver",
				"Slam",
				"Slip",
				"Spark",
				"Speed",
				"Spell",
				"Spin",
				"Spirit",
				"Spit",
				"Splint",
				"Split",
				"Spring",
				//"Spurt",
				"Staff",
				"Stag",
				"Steam",
				"Steel",
				"Stem",
				"Stick",
				"Still",
				"Star",
				"Stop",
				"String",
				"Sword",
				"Thorn",
				"Throw",
				"Thunder",
				"Tire",
				"Toll",
				"Ton",
				"Tooth",
				"Top",
				"Traveller",
				"Tree",
				"Tri",
				"Trim",
				"Troll",
				"Tumble",
				"Twist",
				"Under",
				"Vent",
				"View",
				"Vile",
				"Ville",
				"Wake",
				"Wand",
				"Ware",
				"Wary",
				"Watch",
				"Water",
				"Way",
				"Weather",
				"Weed",
				"While",
				"Whisk",
				"Whisker",
				"Wild",
				"Wish",
				"Wolf",
				"Wood",
				"Wrangle",
				"Yellow"];
				
				 var fantasyNames = [
				"Ad",
				"Adin",
				"Ag",
				"Bek",
				"Berk",
				"Brim",
				"Brin",
				"Brun",
				"Cop",
				"Char",
				"Chur",
				"Cur",
				"Cus",
				"Dain",
				"Dar",
				"Dek",
				"Die",
				"Din",
				"Dis",
				"Dor",
				"Drak",
				"Drake",
				"Dred",
				"Drik",
				"Dun",
				"Ed",
				"Fin",
				"For",
				"Forg",
				"Frog",
				"Fum",
				"Fur",
				"Gar",
				"Ger",
				"Garth",
				"Gon",
				"Graf",
				"Grap",
				"Grat",
				"Grath",
				"Grid",
				"Grim",
				"Grind",
				"Grum",
				"Gun",
				"Hag",
				"Hap",
				"Hel",
				"Ica",
				"Icus",
				"Ja" ,
				"Kik",
				"Kil",
				"Kor",
				"Kris",
				"Mac",
				"Mar",
				"Max",
				"Mer",
				"Morg",
				"Or",
				"Rak",
				"Ren",
				"Rend",
				"Rick",
				"Rid",
				"Rik",
				"Rock",
				"Roy",
				"Run",
				"Rune",
				"Rus",
				"Sa",
				"Sik",
				"Steel",
				"Stell",
				"Seph",
				"Shea",
				"Sif",
				"Syf",
				"Syph",
				"Tan",
				"Ther",
				"Thor",
				"Thud",
				"Thun",
				"Tin",
				"Tor",
				"Tra",
				"Ul",
				"Vis",
				"Vok",
				"Wad",
				"Worth"];
				
<!--Wordlist objects contain the values of each entry in the select dropdown above-->
var wordList = {"fantasy" : fantasyNames, "places" : places};
words = wordList[document.getElementById("genPick").value];//Initialize to the default.	
var generate = generateWord;


 var damageTypes =["Acid",
				"Air",
				"All",
				"Arcane",
				"Blunt",
				"Cold",
				"Falling",
				"Fire",
				"Fire",
				"Frost",
				"Ice",
				"Light",
				"Lightning",
				"Peircing",
				"Physical",
				"Plasma",
				"Shadow",
				"Sonic",
				"Water"]
				
var animals=["Ants",
			"Bears",
			"Bees",
			"Birds",
			"Bobcats",
			"Cats",
			"Cows",
			"Crows",
			"Deer",
			"Dogs",
			"Eagles",
			"Elephants",
			"Elk",
			"Falcons",
			"Fish",
			"Flies",
			"Gazelle",
			"Giraffes",
			"Goats",
			"Gorillas",
			"Hawks",
			"Horses",
			"Kangaroos",
			"Lions",
			"Moles",
			"Monkeys",
			"Moose",
			"Owls",
			"Panthers",
			"Pelicans",
			"Penguins",
			"Pigs",
			"Seal",
			"Sheep",
			"Tigers",
			"Walrii",
			"Wasps",
			"Wolves",
			"Zebras",]
			  
var mysticBeasts=["Dinosaurs",
				"Dragons",
				"Giants",
				"Manticores",
				"Phoenices",
				"Sphinxes",
				"Unicorns"]				
				
var summonables =[
			  water,
			  animals,
			  mysticBeasts,
			  "Beetles",
			  "Bones",
			  "Trees",
			  "Smoke",
			  "Grass blades"]			  
				  

var items =["Amulet",
			"Armor",
			"Axe",
			"Badge",
			"Bar of soap",
			"Baseball bat",
			"Battleaxe",
			"Bell",
			"Bone",
			"Boots",
			"Bottle",
			"Bowler Hat",
			"Bracelet",
			"Broach",
			"Can of spray paint",
			"Cane",
			"Cell phone",
			"Chalk",
			"Charm",
			"Chewing gun",
			"Club",
			"Codpiece",
			"Coin",
			"Compass",
			"Crossbow",
			"Cuff links",
			"Dagger",
			"Deck of cards",
			"Earring",
			"Emerald",
			"Fedora",
			"Fishing Rod",
			"Flail",
			"Flashlight",
			"Flute",
			"Gauntlet",
			"Gargoyle",
			"Gem",
			"Glasses",
			"Gloves",
			"Goggles",
			"Guitar",
			"Gun",
			"Hammer",
			"Hand mirror",
			"Hat",
			"Headset",
			"Horn",
			"Jacket",
			"Key",
			"Kneepads",
			"Knife",
			"Lighter",
			"Locket",
			"Longbow",
			"Lute",
			"Mace",
			"Magnet",
			"Magnifying glass",
			"Monocle",
			"Motorcycle",
			"Necklace",
			"Pebble",
			"Pelt",
			"Pickaxe",
			"Pin",
			"Pocketwatch",
			"Potion",
			"Rapier",
			"Ring",
			"Rod",
			"Sandals",
			"Screwdriver",
			"Shield",
			"Shorts",
			"Shovel",
			"Sombrerro",
			"Spear",
			"Staff",
			"Sweatervest",
			"Tin can",
			"Toupee",
			"Tophat",
			"Torch",
			"Totem",
			"Toy soldier",
			"Trident",
			"Twine",
			"Vest",
			"Wand",
			"Warhammer",
			"Whip",
			"Whistle",
			"Wristwatch"];
	
var senses=["taste",
			"feel",
			"smell",
			"see",
			"hear"]
	
var skills=["Alteration",
			"Athletics",
			"Block",
			"Chemistry",
			"Craft",
			"Creation",
			"Destruction",
			"Disguise",
			"Engineering",
			"Enlightenment",
			"Escape",
			"Heavy armor",
			"Interaction",
			"Knowledge",
			"Language",
			"Light armor",
			"Medicine",
			"Melee Weapon",
			"Perception",
			"Ranged",
			"Restoration",
			"Ride/Drive",
			"Security",
			"Sense Motive",
			"Sleight of Hand",
			"Survival",
			"Stealth",
			"Unarmed Combat"]			
			
//Enchantments	(including function calls), main effects.		
var postEffects=[resist,
				//breathe,
				deals,
				summon,
				ringing,
				extraHP,
				regen,
				ages,
				attr,
				knowNearest,
				growShrink,
				moveItem,
				shrinkCurse,
				ignition,
				shapeshift,
				smells,
				sounds,
				lockpick,
				color,
				onMiss,
				drawings,
				skill,
				bond,
				"of invisibility",
				"of night-vision",
				"of silence",
				"of fireballs",
				"of telepathy",
				"of illumination",
				"of incredible weight",
				"of underwater breathing",
				"of water-walking",
				"on a rope",
				"that makes the user appear unusually attractive",
				"that makes the user appear particularly unattractive",
				"that makes constables and law enforcement pay extra attention to the wielder",
				"that makes constables and law enforcement pay little attention to the wielder",
				"that allows the wielder to understand all languages",
				"that allows the wielder to listen while sleeping",
				"that gives the wielder the ability to teleport between mirrors",
				"that allows the wielder to automatically dodge one attack per day",
				"that allows the wielder to reroll one attack per day",
				"that allows the wielder to walk through walls",
				"that allows the wielder to teleport between any two visible shadows",
				"that can destroy all light sources in sight.",
				"that can create a mirror on any flat surface",
				"that ensures the wielder will win the next competition they enter",
				"that makes all creatues the wielder rides happy",
				"that renders the wielder unable to lie",
				"that makes the brightness of things correspond to their loudness",
				"that acts as a lightning rod",
				"that doubles all healing its wielder does",
				"that sings a faint lullaby every night",
				"that looks as if its seen better days",
				"that seems smaller than usual",
				"that allows the wielder to instantly appraise all gems",
				"that imparts upon the wielder specific details of how every corpse they see died",
				"that constantly chants the names of every body of water within a mile",
				"that makes merchants want to cut a bargain",
				"that amplifies every sound the wielder makes",
				"that muffles every sound the wielder makes",
				"that allows the wielder to attack from an additional square away",
				"that marks the wielder as a member of every known guild",
				"that ensures safe passage from all masons and builders",
				"that bears an emblem known to no man, but respected by all criminals",
				"that marks the wielder for death",
				"that infuriates all animals who see it",
				"that pushes anyone hit by it one square away",
				"that has an odd way of getting lost",
				"that renders the wielder incapable of walking in a straight line",
				"that gives off heat like a fire",
				"that can burrow into the ground",
				"that allows the wielder the ability to see through walls",
				"that renders the wielder impervious to the cold",
				"that removes the wielder's need to breathe",
				"that removes the wielder's need to eat",
				"that can be summoned or dismissed at will",
				"that knows the memories of everything the wielder touches",
				"that renders the wielder unable to speak the truth",
				"that has a strange pull towards items made of iron",
				"that buzzes faintly",
				"that is hot to the touch",
				"that forces the wielder to always grant combat advantage",
				"that allows the wielder to stand as a free action",
				"that allows the wielder to shift an extra square",
				"that renders the wielder immune to opportunity attacks",
				"that is cold to the touch",
				"that seems to grow and shrink at random times",
				"that is prettier at night",
				"that reminds you of your mother",
				"that knows and shares the secrets of its previous wielders",
				"that knows the location of all keys",
				"that renders the wielder fireproof",
				"that generates a perpetual raincloud above the user",
				"that renders the wielder imprevious to weather effects",
				"that always returns when thrown",
				"that seems to want to crawl away",
				"that allows the wielder to climb any surface at their normal walking speed",
				"that allows the wielder to walk on walls",
				"that renders the wielder impervious to the next five ranged attacks",
				"that can absorb the next spell cast at the wielder, and then cast it for free once a day",
				"that seems to be made from a series of impossible angles",
				"that deals whatever type of damage was last dealt to its wearer",
				"that makes animals friendly to the wielder.",
				"that always points North",
				"which cannot be willfully given away, only stolen",
				"which cannot be stolen, only willfully given away",
				"which cures all ails of those the wielder touches, transferring them to the wielder",
				"which grants flight to its wearer",
				"which makes the wielder appear invisible to mirrors and cameras",
				"which produces random weekly hallucinations in the wielder",
				"which reduces the wielder's HP by 10%",
				"which renders the wielder unable to become drunk",
				"which whispers the thoughts of everyone the wielder kills",
				"which will regenerate the last wielder 24 hours after his or her death, provided no one touches it in that time"]
 
 var colors=["Red",
			"Blue",
			"Green",
			"Yellow",
			"Orange",
			"Indigo",
			"Violet",
			"Fuchsia",
			"Cyan",
			"Maroon",
			"Black",
			"White",
			"Crimson",
			"Brown",
			"Rainbow",
			"Grey",
			"Turqouise",
			"Teal",
			"Pink",
			"Purple",
			"Piss-yellow"];
 
 //Mostly adjectives
 var preEffects=[
				"Ancient",
				"Bent",
				colors,
				"Bejeweled",
				 "Broken",
				"Cloth",
				 "Cold",
				 "Crystal",
				 "Cursed",
				 "Enormous",
				 "Ever-glowing",
				"Flamethrowing",
				"Flying",
				"Grotesque",
				"Hairy",
				"Heavy",
				"Haunted",
				"Hot",
				"Intelligent",
				"Jagged",
				"Old-fashioned",
				"Regal",
				"Rusty",
				"Sacrificial",
				"Singing",
				"Smooth",
				"Soft",
				"Stone",
				"Talking",
				"Tacky",
				"Thorny",
				"Tiny",
				"Ugly",
				"Wet",
				"Wooden"];

var frequency=["Per day",
			   "Per hour",
			   "Per year",
			   "Per second",
			   "At once",
			   "Per minute",
			   "Per round",
			   "Per lifetime",
			   "Each time a crime is committed by the wielder",
			   "Until everyone who witnessed it has died",
			   "Per week"];
 
 var waterUnits=["Gallons",
				 "Buckets",
				 "Puddles",
				 "Lakes",
				 "Ounces",
				 "Liters",
				 "Milliliters",
				 "Pounds",
				 "Tons",
				 "Bathtubs",
				 "Bottles"];
				 
var timeUnits=["Seconds",
			   "Minutes",
			   "Hours"]
			   
var lengthUnits=["Inches",
				"Millimeters",
				"Feet",
				"Centimeters",
				"Meters",
				"Yards",
				"Miles"]
			
//Any non skill that can be increased mostly			
var attr=["Speed",
		  "Strength",
		  "Armor Class",
		  "Fortitude",
		  "Luck",
		  "Charisma",
		  "Will",
		  "Reflex",
		  "Dexterity",
		  "Intelligence",
		  "Wisdom",
		  "Constitution"];

var ingredients=[flowers,
				 bone,
				"A secret"]



//The state of flowers				
var flowerState=["Crushed",
				 "Freshly-Picked",
				 "Ground",
				 "Rare",
				 "Common",
				 "Exotic",
				 "Dying",
				 "Newly-sprouted",
				 "Ancient",
				 "Foreign"]
		  
var flowerTypes=["Tulips",
				 "Roses",
				 "Daffodils",
				 "Sunflowers",
				 "Dandelions",
				 "Lillies",
				 "Thorns",
				 "Oak Petals",
				 "Willow Leaves",
				 "Maple Leaves",
				 "Bark",
				 "Baby's breath",
				 "Carnations",
				 "Forget-me-not",
				 "Foxgloves",
				 "Thistles",
				 "Hyacinth",
				 "Iris",
				 "Larkspurs",
				 "Lavenders",
				 "Marigolds",
				 "Orchids",
				 "Peony",
				 "Snapdragon",
				 "Tulips",
				 "Chrysanthemums"]
	
var boneSourceType=["Freshly-killed",
					"Living",
					"Newborn",
					"Ancient"]
	
var boneSource=[animals,
				mysticBeasts,
				"Human"]
				

	
function setWords()
{
	document.getElementById('display').innerHTML = "<br>";//Clear the list
	var dropdownValue = document.getElementById("genPick").value;
	words = wordList[dropdownValue];
	if(dropdownValue === "items")
	{
		generate = generateItem;
	}
	else if(dropdownValue === "ingredients")
	{
		generate = generateIngredient
	}
	else
	{
		generate = generateWord;
	}
}
  
 //Used for places, names, and other combinations of two items.
function generateWord()
 {
					var word1 = getSomething(words);
					do
					{
						var word2 = getSomething(words);
					}
					while(word1 === word2);
					return word1 + word2.toLowerCase();			
}
 

 //This function could be avoided and we could invoke the other one directly IF
 //We could figure out how to pass in an argument when invoking a function by reference.
 function generateIngredient()
 {
	return getSomething(ingredients);
}
			
//Start here
function updateText(num)
{
		document.getElementById('display').innerHTML = "<br>";
		for(var i = 0; i< num; i++)
		{
			document.getElementById('display').innerHTML += generate() + "<br>";
		}
}			
			
			
//Piece together item, description, and enchantment	
function generateItem()
{
		var rand = Math.round(Math.random() * 100);
		var obj = getSomething(items) + " ";
		var ret = obj;
		var single = false;//Used to keep track of multiple conditions (do we need an "and"?)
		if(rand < 60)//adjective
		{
			ret = getSomething(preEffects) +  " " + obj.toLowerCase();
		}
		rand = Math.round(Math.random() * 100);
		if(rand < 30)//Add a description
		{
			ret = ret + getSomething(postEffects);
			single = true;
		}
		rand = Math.round(Math.random() * 100);
		if(rand < 30)//Add a description
		{
			if(single)
			{
				do//Keep resetting until it isn't the same effect.
				{
					var secEff = getSomething(postEffects);
				}
				while(secEff === ret);
				ret = ret + " and " + secEff;
			}
			else
			{
				ret = ret + getSomething(postEffects);
			}
		}
		return fixGrammar(ret);
}	

//Effect functions
  function extraHP()
  {
  	return " that grants the wielder " + getHighNum() + " extra hit points";
  }
  
  function growShrink()
  {
	var rand = Math.round(Math.random());
	var action;
	if(rand % 2 == 0)
	{
		action = "grow";
	}
	else
	{
		action = "shrink"
	}
	return "which allows the user to " + action.toLowerCase() + " any item they are touching by " + getLowNum() + " " + getSomething(lengthUnits).toLowerCase();
	
  }
  
  function moveItem()
  {
	return "that allows the user to teleport any item or person they can see by " + getLowNum() + " " + getSomething(lengthUnits).toLowerCase();
  }
  
  function shrinkCurse()
  {
	return "which shrinks the user by " + getLowNum() + " " + getSomething(lengthUnits).toLowerCase() + " whenever it is used"
  }
  
  
  function regen()
  {
	var time = getSomething(timeUnits);
	time = time.substring(0, time.length-1).toLowerCase();
	return " that allows the wielder to regenerate " + getLowNum() + " hit points per " + time;
  }
  
 //Returns a string containing damage type and amount
 function summon()
 {
	return " that can summon " + getLowNum() + " " + getSomething(summonables).toLowerCase() + " " + getSomething(frequency).toLowerCase();
 }
 
 function knowNearest()
 {
	return "which allows the wielder to know the location of the closest "+ getSomething(summonables).toLowerCase();
 }
 
 function ignition()
 {
	return "which allows the wielder to set fire to any flammable object once "+ getSomething(frequency).toLowerCase();
 }
 
 function color()
 {
  return "that makes everything appear " + getSomething(colors).toLowerCase();
 }
 
 function onMiss()
 {
	return "that deals " + getLowNum() + " " + getSomething(damageTypes).toLowerCase() + " damage to an enemy when they miss you with an attack"
 }
 
 function drawings()
 {
	var time = getSomething(timeUnits);
	time = time.substring(0, time.length-1).toLowerCase();
	if (time === "hour")
	{
	
		time = "n hour"; //grammar is important 
	}
	else
	{//Remove awkward "a n hour" from 'fix' above.
		time = " " + time;
	}
	return 	"that can make the wielder's drawings come alive for a" + time;
 }
 
 function skill()
 {
	return "that gives the wielder a + " + getLowNum() + " bonus to " + getSomething(skills);
 }
 
 function bond()
 {
	var temp = getSomething(senses);
	return "that lets the user " + temp + " whatever it could " + temp
 }
 
 function shapeshift()
 {
	return "that allows the wielder the ability to transform into a " + getSomething(summonables).toLowerCase() + " (and back!)";
 }
 
 function smells()
 {
	return "that destroys all smells within " + getLowNum() + " " + getSomething(lengthUnits).toLowerCase();
 }
 
 function sounds()
 {
	return "that destroys all sounds within " + getLowNum() + " " + getSomething(lengthUnits).toLowerCase();
 }
 
 function lockpick()
 {
  return "that can automatically pick a lock " + getSomething(frequency).toLowerCase();
 }
 
 function ages()
 {
	return "that ages anything it touches " + getLowNum() + " years";
 }
 
 
 function attr()
 {
	return "that increases the " + getSomething(attr) + " of its wielder by " + getLowNum();
 }
 
 //Returns a string containing damage type and amount
 function resist()
 {
	return " of resist " + getLowNum() + " " + getSomething(damageTypes).toLowerCase();
 }
 
 function deals()
{
	return "which deals " + getSomething(damageTypes).toLowerCase() + " damage";
 }
 
/* function breathe()
 {
	return "which allows the wielder to breathe " + getSomething(damageTypes).toLowerCase() + " energy";
 }
 */
  function ringing()
 {
	 return "which emits a loud ringing for " + getHighNum() + " " + getSomething(timeUnits).toLowerCase() + " at noon sharp";
 }
 
//Getters	
	
//Rturns a random element of a list (something), unless that element is a list itself, then
//it returns a random element of THAT list, unless that element is a function, then
//it invokes that function.
 function getSomething(something)
 {
	var ret =  something[Math.round(Math.random()*(something.length-1))]
	if (typeof ret === "string")
	{
		return ret;
	}
	else if( Object.prototype.toString.call( ret ) === '[object Array]' ) {
		return getSomething(ret);
	}
	else
	{
		return ret();
	}
 }
 
 //Ingredient Helpers
 function flowers()
 {
	return getLowNum() + " " + getSomething(flowerState) + " " + getSomething(flowerTypes);
 }
 
 function bone()
 {
	//TODO
 }
 
 //These are sometimes invoked directly, and I don't know how to pass in an argument like that.
 //Returns an amount of water
 function water()
 {
	return waterUnits[Math.round(Math.random()*(waterUnits.length-1))] + " of water";
 }	
	
	
			
//Returns a number between 1 and 6
function getLowNum()
{
return Math.round(Math.random()*(6)) + 1;
}

//Returns a number between 5 and 25
function getHighNum()
{
	return (Math.round(Math.random()*(5))) * 5 + 1;
}

//Fixes grammatical mistakes
 function fixGrammar(str)
 {
	//Change a to an if followed by a vowel
	var re = /^(a )([aeiou])/g
	str = str.replace(re, "an $2");
	//Fix "a bones" quantity disagreement errors
	//Search for any letter ending in an s, but not
	//Ending in 'ss' or starting wtih s (grass, series)
	re = /(a [a-rt-z][a-z]+[^s])s\b/igm
	str = str.replace(re, "$1")
	//Replace "a smoke" with "smoke"
	str.replace("a smoke","smoke");
	return str;
 }