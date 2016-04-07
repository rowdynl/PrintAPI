
namespace Rowdy.API.PrintAPI
{
    /// <summary>
    /// Address format
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Optional company name
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// Full name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// First address line
        /// </summary>
        public string line1 { get; set; }
        /// <summary>
        /// Second address line
        /// </summary>
        public string line2 { get; set; }
        /// <summary>
        /// Postal code (ZIP code)
        /// </summary>
        public string postCode { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// ISO 3166-1-alpha-2 country code
        /// </summary>
        public string country { get; set; }
    }

    /// <summary>
    /// The status of a Print API checkout payment
    /// </summary>
    public class PaymentStatus
    {
        /// <summary>
        /// The payment is open
        /// </summary>
        public const string Open = "Open";
        /// <summary>
        /// The payment failed
        /// </summary>
        public const string Failed = "Failed";
        /// <summary>
        /// The payment succeeded
        /// </summary>
        public const string Successful = "Successful";
        /// <summary>
        /// The payment was cancelled
        /// </summary>
        public const string Cancelled = "Cancelled";
    }

    /// <summary>
    /// ISO 3166-1 alpha 2 country codes
    /// </summary>
    public class Country
    {
        public const string Afghanistan = "AF";
        public const string AlandIslands = "AX";
        public const string Albania = "AL";
        public const string Algeria = "DZ";
        public const string AmericanSamoa = "AS";
        public const string Andorra = "AD";
        public const string Angola = "AO";
        public const string Anguilla = "AI";
        public const string Antarctica = "AQ";
        public const string AntiguaandBarbuda = "AG";
        public const string Argentina = "AR";
        public const string Armenia = "AM";
        public const string Aruba = "AW";
        public const string Australia = "AU";
        public const string Austria = "AT";
        public const string Azerbaijan = "AZ";
        public const string BahamasThe = "BS";
        public const string Bahrain = "BH";
        public const string Bangladesh = "BD";
        public const string Barbados = "BB";
        public const string Belarus = "BY";
        public const string Belgium = "BE";
        public const string Belize = "BZ";
        public const string Benin = "BJ";
        public const string Bermuda = "BM";
        public const string Bhutan = "BT";
        public const string Bolivia = "BO";
        public const string BonaireSaintEustatiusandSaba = "BQ";
        public const string BosniaandHerzegovina = "BA";
        public const string Botswana = "BW";
        public const string BouvetIsland = "BV";
        public const string Brazil = "BR";
        public const string BritishIndianOceanTerritory = "IO";
        public const string BruneiDarussalam = "BN";
        public const string Bulgaria = "BG";
        public const string BurkinaFaso = "BF";
        public const string Burundi = "BI";
        public const string Cambodia = "KH";
        public const string Cameroon = "CM";
        public const string Canada = "CA";
        public const string CapeVerde = "CV";
        public const string CaymanIslands = "KY";
        public const string CentralAfricanRepublic = "CF";
        public const string Chad = "TD";
        public const string Chile = "CL";
        public const string China = "CN";
        public const string ChristmasIsland = "CX";
        public const string CocosKeelingIslands = "CC";
        public const string Colombia = "CO";
        public const string Comoros = "KM";
        public const string Congo = "CG";
        public const string CongoTheDemocraticRepublicofthe = "CD";
        public const string CookIslands = "CK";
        public const string CostaRica = "CR";
        public const string CoteDivoire = "CI";
        public const string Croatia = "HR";
        public const string Curacao = "CW";
        public const string Cyprus = "CY";
        public const string CzechRepublic = "CZ";
        public const string Denmarke = "DK";
        public const string Djibouti = "DJ";
        public const string Dominica = "DM";
        public const string DominicanRepublic = "DO";
        public const string Ecuador = "EC";
        public const string Egypt = "EG";
        public const string ElSalvador = "SV";
        public const string EquatorialGuinea = "GQ";
        public const string Eritrea = "ER";
        public const string Estonia = "EE";
        public const string Ethiopia = "ET";
        public const string FalklandIslandsMalvinas = "FK";
        public const string FaroeIslands = "FO";
        public const string Fiji = "FJ";
        public const string Finland = "FI";
        public const string France = "FR";
        public const string FrenchGuiana = "GF";
        public const string FrenchPolynesia = "PF";
        public const string FrenchSouthernTerritories = "TF";
        public const string Gabon = "GA";
        public const string GambiaThe = "GM";
        public const string Georgia = "GE";
        public const string Germany = "DE";
        public const string Ghana = "GH";
        public const string Gibraltar = "GI";
        public const string Greece = "GR";
        public const string Greenland = "GL";
        public const string Grenada = "GD";
        public const string Guadeloupe = "GP";
        public const string Guamv = "GU";
        public const string Guatemala = "GT";
        public const string Guernsey = "GG";
        public const string Guinea = "GN";
        public const string GuineaBissau = "GW";
        public const string Guyana = "GY";
        public const string Haiti = "HT";
        public const string HeardIslandandtheMcDonaldIslands = "HM";
        public const string HolySee = "VA";
        public const string Honduras = "HN";
        public const string HongKong = "HK";
        public const string Hungary = "HU";
        public const string Iceland = "IS";
        public const string India = "IN";
        public const string Indonesia = "ID";
        public const string Iraq = "IQ";
        public const string Ireland = "IE";
        public const string IsleofMan = "IM";
        public const string Israel = "IL";
        public const string Italy = "IT";
        public const string Jamaica = "JM";
        public const string Japan = "JP";
        public const string Jersey = "JE";
        public const string Jordan = "JO";
        public const string Kazakhstan = "KZ";
        public const string Kenya = "KE";
        public const string Kiribati = "KI";
        public const string KoreaRepublicof = "KR";
        public const string Kuwait = "KW";
        public const string Kyrgyzstan = "KG";
        public const string LaoPeoplesDemocraticRepublic = "LA";
        public const string Latvia = "LV";
        public const string Lebanon = "LB";
        public const string Lesotho = "LS";
        public const string Liberia = "LR";
        public const string Libya = "LY";
        public const string Liechtenstein = "LI";
        public const string Lithuania = "LT";
        public const string Luxembourg = "LU";
        public const string Macao = "MO";
        public const string MacedoniaTheFormerYugoslavRepublicof = "MK";
        public const string Madagascar = "MG";
        public const string Malawi = "MW";
        public const string Malaysia = "MY";
        public const string Maldives = "MV";
        public const string Mali = "ML";
        public const string Malta = "MT";
        public const string MarshallIslands = "MH";
        public const string Martinique = "MQ";
        public const string Mauritania = "MR";
        public const string Mauritius = "MU";
        public const string Mayotte = "YT";
        public const string Mexico = "MX";
        public const string MicronesiaFederatedStatesof = "FM";
        public const string MoldovaRepublicof = "MD";
        public const string Monaco = "MC";
        public const string Mongolia = "MN";
        public const string Montenegro = "ME";
        public const string Montserrat = "MS";
        public const string Morocco = "MA";
        public const string Mozambique = "MZ";
        public const string Myanmar = "MM";
        public const string Namibia = "NA";
        public const string Nauru = "NR";
        public const string Nepal = "NP";
        public const string Netherlands = "NL";
        public const string NetherlandsAntilles = "AN";
        public const string NewCaledonia = "NC";
        public const string NewZealand = "NZ";
        public const string Nicaragua = "NI";
        public const string Niger = "NE";
        public const string Nigeria = "NG";
        public const string Niue = "NU";
        public const string NorfolkIsland = "NF";
        public const string NorthernMarianaIslands = "MP";
        public const string Norway = "NO";
        public const string Oman = "OM";
        public const string Pakistan = "PK";
        public const string Palau = "PW";
        public const string PalestinianTerritories = "PS";
        public const string Panama = "PA";
        public const string PapuaNewGuinea = "PG";
        public const string Paraguay = "PY";
        public const string Peru = "PE";
        public const string Philippines = "PH";
        public const string Pitcairn = "PN";
        public const string Poland = "PL";
        public const string Portugal = "PT";
        public const string PuertoRico = "PR";
        public const string Qatar = "QA";
        public const string Reunion = "RE";
        public const string Romania = "RO";
        public const string RussianFederation = "RU";
        public const string Rwanda = "RW";
        public const string SaintBarthelemy = "BL";
        public const string SaintHelenaAscensionandTristandaCunha = "SH";
        public const string SaintKittsandNevis = "KN";
        public const string SaintLucia = "LC";
        public const string SaintMartin = "MF";
        public const string SaintPierreandMiquelon = "PM";
        public const string SaintVincentandtheGrenadines = "VC";
        public const string Samoa = "WS";
        public const string SanMarino = "SM";
        public const string SaoTomeandPrincipe = "ST";
        public const string SaudiArabia = "SA";
        public const string Senegal = "SN";
        public const string Serbia = "RS";
        public const string Seychelles = "SC";
        public const string SierraLeone = "SL";
        public const string Singapore = "SG";
        public const string SintMaarten = "SX";
        public const string Slovakia = "SK";
        public const string Slovenia = "SI";
        public const string SolomonIslands = "SB";
        public const string Somalia = "SO";
        public const string SouthAfrica = "ZA";
        public const string SouthGeorgiaandtheSouthSandwichIslands = "GS";
        public const string SouthSudan = "SS";
        public const string Spain = "ES";
        public const string SriLanka = "LK";
        public const string Suriname = "SR";
        public const string SvalbardandJanMayen = "SJ";
        public const string Swaziland = "SZ";
        public const string Sweden = "SE";
        public const string Switzerland = "CH";
        public const string Taiwan = "TW";
        public const string Tajikistan = "TJ";
        public const string TanzaniaUnitedRepublicof = "TZ";
        public const string Thailand = "TH";
        public const string Timorleste = "TL";
        public const string Togo = "TG";
        public const string Tokelau = "TK";
        public const string Tonga = "TO";
        public const string TrinidadandTobago = "TT";
        public const string Tunisia = "TN";
        public const string Turkey = "TR";
        public const string Turkmenistan = "TM";
        public const string TurksandCaicosIslands = "TC";
        public const string Tuvalu = "TV";
        public const string Uganda = "UG";
        public const string Ukraine = "UA";
        public const string UnitedArabEmirates = "AE";
        public const string UnitedKingdom = "GB";
        public const string UnitedStates = "US";
        public const string UnitedStatesMinorOutlyingIslands = "UM";
        public const string Uruguay = "UY";
        public const string Uzbekistan = "UZ";
        public const string Vanuatu = "VU";
        public const string Venezuela = "VE";
        public const string Vietnam = "VN";
        public const string VirginIslandsBritish = "VG";
        public const string VirginIslandsUS = "VI";
        public const string WallisandFutuna = "WF";
        public const string WesternSahara = "EH";
        public const string Yemen = "YE";
        public const string Zambia = "ZM";
        public const string Zimbabwe = "ZW";
    }
}

