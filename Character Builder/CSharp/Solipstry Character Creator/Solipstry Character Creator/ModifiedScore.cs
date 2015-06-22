using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solipstry_Character_Creator
{
	class ModifiedScore
	{
		public string modifiedScore; //What score is being modified (i.e. Strength, Perception, etc.)
		public string modifiedBy; //The talent that caused the modification
		public bool userMarks; //Whether the user needs to mark this on their own
	}
}
