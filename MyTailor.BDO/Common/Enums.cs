using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyTailor.BDO.Common
{

    public enum SuitSubItemTypes
    {
        Slacks = 1,
        Vest = 2,
        TuxedoSlacks = 3,
        TuxedoVest = 4
    }

    public enum TypeOfSizes
    {
        OrderMeasurementJacketSize = 1,
        OrderMeasurementSlackVestTopCoatSize = 2,
        OrderMeasurementShirtSize = 3,
        OrderFinishedJacketSize = 4,
        OrderFinishedSlackVestTopCoatSize = 5,
        OrderFinishedShirtSize = 6
    }

    public enum OrderOriginatedFrom
    {
        Portal = 1,
        MyTailorDotCom = 2
    }

    public enum TypeOfAddress
    {
        Residential = 1,
        Business = 2        
    }

    public enum OrderItemTypes
    {
        Suit = 1,
        Shirt = 2,
        Slacks = 3,
        Tuexedo = 4,
        Vest = 5,
        TopCoat = 6,
        Belt = 7,
        KnitShort = 8,
        Jacket = 9,
        Buttons = 10,
        WCC = 11,
        BowTie = 12,
        Cuffs = 13,
        Collor = 14,
        JLining = 15,
        Pockets = 16,
        CAndCuffs = 17,
        Mono = 18,
        Kamerb = 19,
        PB = 20,
        FormaTuexedoShirts = 21,
        Fabric = 22,
        Ties = 23,
        TuexedoJacket = 24,
        TuexedoSlack = 25,
        TuexedoVest = 26,
        Alteration = 27,
        Blouse = 28,
        SportsJacket = 29,
        WesterJacket = 30,
        SuitSacket = 31,
        CuffLinks = 32,
        Paijama = 33,
        Handkerchiefs = 34,
        CollorPins = 35,
        Shorts = 36,
        SampleGarments = 99
    }

    public enum ShipmentTypes
    {
        PickedUpInHK = 1,
        PickedUpInCostaMesa = 2,
        SpeedPostDirectToCustomer = 3
    }

    public enum OrderTypes
    {
        NormalOrder = 1,
        FitConfirmation = 2,
        RushDelivery = 3
    }

    public enum OrderPaymentTypes
    {
        Cash = 1,
        Check = 2,
        GiftCertificate = 3,
        CreditCard = 4
    }

    public enum FabricWidths
    {
        ThirtySixInches = 1,
        FortyFiveInches = 2,
        SixtyInches = 3
    }

    public enum MonogramTypes
    {
        Mono01 = 1,
        Mono02 = 2,
        Mono03 = 3,
        Mono04 = 4,
        Mono05 = 5,
        Mono06 = 6,
        Mono07 = 7,
        Mono08 = 8,
        Mono09 = 9,
        Mono10 = 10,
        Mono11 = 11,
        Mono12 = 12,
        Mono13 = 13,
        Mono14 = 14,
        Mono15 = 15,
        Mono16 = 16,
        Mono17 = 17,
        Mono18 = 18,
        Mono19 = 19,
        Mono20 = 20,
        Mono21 = 21,
        Mono22 = 22,
        Mono23 = 23,
        Mono24 = 24,
        Mono25 = 25,
        Mono26 = 26,
        Mono27 = 27,
        Mono28 = 28,
        Mono29 = 29,
        Mono30 = 30,
        Custom = 98,
        Handwriting = 99
    }
}
