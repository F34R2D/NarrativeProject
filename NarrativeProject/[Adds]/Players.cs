using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    [Serializable]
    public class Players
    {
        public int id;
        public string name;
        public int health = 100;
        public int damage = 1;
        public int medkit = 0;
        public int armor = 5;
        public int weaponD = 0;

        //testing the storage of KeyEvents for Save&LoadsLe
        internal static bool isFlashlightCollected;
        internal static bool isBathroomMedTaken;
        
        public static bool isSecondEventTriggered = false;
        public static bool isFirstEventTriggered = false;
        internal static bool isToolsPickedUp;
        internal static bool isPuzzleResolved;
        internal static bool isGeneratorRoomChecked;
        
        

    }
    

    
}
