using Dsd601CarpetCalcAsp.Model;

namespace Dsd601CarpetCalcAsp.Operations

{

    public class CarpetOperations
    {
        public float TotalInstallCost(Carpet carpet)
        {

            carpet.FinalCost += (carpet.CarpetType * carpet.RoomArea);


            //switch (carpet.CarpetType)
            //{
            //    case 100:
            //        carpet.FinalCost += (100 * carpet.RoomArea);
            //        break;

            //    case 2:
            //        carpet.FinalCost += (200 * carpet.RoomArea);
            //        break;


            //    case 3:
            //        carpet.FinalCost += (300 * carpet.RoomArea);
            //        break;

            //    default:
            //        break;
            //}


            if (carpet.HasInstallation)
            {
                carpet.FinalCost += (carpet.InstallationCost * carpet.RoomArea);
            }

            if (carpet.HasUnderlay)
            {
                carpet.FinalCost += (carpet.UnderlayCost * carpet.RoomArea);
            }

            return carpet.FinalCost;
        }


        //========================= Supplier==================

        public int CalcCarpetRolls(float roomLength, float roomWidth)
        {
            // carpet rolls are 1mtr wide by 4mtr long

            var carpetRollWidth = 1;
            var carpetRollLength = 4;

            //count how many times the width of the carpet goes into the width of the room
            var widthCounter = (int)(roomWidth / carpetRollWidth);

            //if there is anything left over, add 1 to the total width
            if (roomWidth % carpetRollWidth > 0)
            {
                widthCounter++;
            }
            //find the total length of the carpet you need to lay
            var totalLength = widthCounter * roomLength;

            //divide by the length of a carpet roll to find out how many rolls you need
            var carpetRolls = (int)totalLength / carpetRollLength;

            //if there is aything left over get another full roll
            //Using Mod to get the remainder
            if (totalLength % carpetRollLength > 0)
            {
                carpetRolls++;
            }
            return carpetRolls;
        }

        public string CalcWastedCarpet(float roomArea, float rolls)
        {
            // carpet rolls are 1mtr wide by 4mtr long

            var rollWidth = 1;
            var rollLength = 4;


            var rollArea = rolls * (rollWidth * rollLength);
            var wastage = rollArea - roomArea;
            return wastage.ToString();

        }

        //list of rooms and costs String Concat
        public string RoomSummary(float roomLength, float roomWidth, string underlay, string carpet, string install, float total)
        {
            return $"Length {roomLength}  Width {roomWidth}   Underlay: {underlay}  Carpet: {carpet}  Installation: {install}    Total = ${total}";
        }


        //return the cost of all the room calculations
        //public float TotalCost(float total)
        //{
        //    _sumTotal += total;
        //    return _sumTotal;
        //}
    }
}
