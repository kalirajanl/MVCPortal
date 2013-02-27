using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Orders
{
    public class OrderItemShirtStyle
    {
        public string SpecialInstructions { get; set; }
        public string StyleName { get; set; }
        public string StyleNumber { get; set; }
        public string CollorNumber { get; set; }
        public string CollorLength { get; set; }
        public string CollorHeight { get; set; }
        public string CollorNotes { get; set; }
        public string CollorSetting { get; set; }
        public string CollorSettingNotes { get; set; }
        public string Stays { get; set; }
        public string StaysNotes { get; set; }
        public string Finishing { get; set; }
        public string FinishingNotes { get; set; }
        public string StichingType { get; set; }
        public string Buttons { get; set; }
        public string StichingTypeButtonsNotes { get; set; }
        public string ShoulderYoke { get; set; }
        public string ShoulderYokeNotes { get; set; }
        public string BackStyle { get; set; }
        public string BackStyleNotes { get; set; }
        public string FrontStyle { get; set; }
        public string FrontStyleNotes { get; set; }
        public string PocketStyleNumber { get; set; }
        public string PocketStyleNumberOfPockets { get; set; }
        public string PocketStyleNotes { get; set; }
        public string ContrastingCollorAndCuff { get; set; }
        public string ContrastingCollorAndCuffNotes { get; set; }
        public string Location { get; set; }
        public string Color { get; set; }
        public MonogramData MongramInfo { get; set; }
        public string LocationAndColorNotes { get; set; }
        public string CuffNumberAndWidth { get; set; }
        public string CuffNumberAndWidthNotes { get; set; }
        public string ShirtTails { get; set; }
        public string ShirtTailsNotes { get; set; }
    }
}
