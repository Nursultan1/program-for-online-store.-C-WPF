﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApplication3
{
    class DataGridZakaz
    {
        byte[] defaultImg = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 201, 0, 0, 0, 107, 8, 2, 0, 0, 0, 82, 112, 49, 183, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 4, 81, 73, 68, 65, 84, 120, 94, 237, 218, 235, 149, 155, 48, 20, 133, 209, 212, 69, 65, 174, 199, 213, 208, 140, 139, 153, 92, 244, 0, 73, 92, 100, 17, 56, 241, 44, 175, 111, 255, 202, 232, 253, 56, 99, 67, 146, 63, 63, 128, 6, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 10, 217, 130, 202, 61, 217, 154, 31, 127, 28, 211, 243, 53, 88, 143, 111, 116, 227, 231, 214, 107, 126, 78, 41, 53, 143, 217, 75, 205, 235, 77, 61, 190, 203, 173, 223, 137, 57, 60, 143, 57, 21, 52, 222, 213, 227, 171, 144, 45, 168, 144, 45, 168, 144, 45, 168, 252, 154, 108, 217, 155, 192, 99, 138, 213, 102, 122, 60, 183, 199, 125, 255, 45, 115, 115, 248, 190, 185, 235, 152, 91, 190, 108, 174, 170, 96, 241, 154, 139, 5, 88, 213, 84, 191, 113, 188, 230, 180, 194, 208, 167, 108, 108, 139, 45, 26, 142, 172, 118, 215, 38, 156, 136, 87, 122, 161, 165, 191, 217, 241, 1, 47, 251, 29, 217, 178, 139, 178, 27, 74, 87, 185, 190, 111, 166, 195, 89, 122, 109, 215, 28, 79, 33, 159, 91, 174, 77, 63, 236, 89, 6, 194, 88, 203, 164, 219, 16, 211, 244, 140, 7, 62, 61, 83, 215, 102, 216, 118, 165, 86, 29, 11, 140, 69, 233, 177, 70, 127, 29, 63, 183, 28, 94, 109, 158, 162, 104, 109, 156, 82, 111, 11, 126, 233, 232, 102, 135, 167, 190, 70, 146, 173, 119, 234, 44, 132, 94, 78, 81, 110, 56, 63, 202, 202, 246, 182, 150, 198, 213, 231, 70, 43, 157, 247, 214, 195, 78, 187, 109, 159, 230, 43, 203, 83, 183, 114, 234, 109, 85, 85, 247, 106, 177, 39, 86, 235, 204, 176, 22, 214, 165, 110, 75, 183, 52, 149, 117, 55, 107, 198, 167, 190, 226, 243, 159, 91, 161, 176, 237, 145, 91, 238, 15, 38, 158, 128, 119, 96, 7, 154, 115, 180, 145, 157, 206, 203, 7, 231, 242, 201, 153, 126, 52, 105, 5, 101, 91, 167, 40, 218, 221, 232, 170, 183, 218, 102, 97, 198, 114, 103, 218, 82, 175, 229, 194, 43, 109, 202, 252, 205, 158, 153, 250, 138, 143, 103, 43, 151, 249, 142, 238, 209, 191, 45, 87, 121, 142, 246, 165, 209, 253, 6, 13, 94, 225, 209, 47, 116, 170, 39, 58, 204, 150, 123, 205, 65, 111, 181, 109, 167, 248, 137, 230, 13, 229, 15, 255, 174, 101, 103, 179, 227, 83, 95, 241, 241, 108, 197, 13, 141, 239, 39, 182, 63, 159, 173, 172, 215, 115, 185, 13, 91, 97, 120, 138, 79, 15, 125, 255, 45, 91, 249, 187, 210, 27, 170, 217, 66, 173, 215, 242, 104, 179, 227, 83, 95, 241, 75, 178, 213, 187, 241, 218, 217, 246, 229, 137, 165, 63, 122, 157, 195, 47, 185, 85, 173, 207, 82, 78, 144, 132, 217, 202, 215, 235, 15, 229, 15, 255, 166, 101, 250, 163, 59, 119, 217, 181, 63, 245, 21, 191, 229, 59, 209, 239, 50, 231, 109, 111, 226, 1, 248, 183, 229, 170, 78, 236, 224, 192, 157, 83, 253, 135, 108, 157, 169, 48, 219, 164, 246, 252, 191, 182, 112, 150, 226, 150, 13, 180, 76, 63, 28, 46, 107, 100, 234, 43, 62, 255, 44, 159, 118, 100, 133, 237, 17, 88, 243, 221, 72, 199, 247, 123, 164, 62, 177, 188, 132, 106, 0, 239, 80, 157, 137, 14, 231, 142, 21, 206, 154, 186, 171, 205, 179, 154, 98, 98, 111, 45, 94, 217, 72, 75, 119, 179, 139, 241, 169, 175, 184, 53, 91, 105, 113, 135, 171, 203, 123, 173, 235, 115, 169, 157, 65, 145, 175, 240, 236, 179, 31, 200, 31, 162, 39, 45, 106, 61, 95, 103, 4, 239, 80, 83, 179, 242, 90, 114, 207, 246, 170, 98, 119, 111, 69, 221, 213, 250, 167, 229, 173, 197, 43, 235, 182, 236, 109, 118, 49, 62, 245, 21, 55, 102, 235, 204, 255, 177, 217, 221, 78, 174, 41, 56, 201, 218, 134, 40, 99, 216, 99, 17, 141, 29, 138, 53, 109, 39, 123, 80, 98, 157, 242, 223, 186, 47, 183, 100, 27, 11, 229, 219, 250, 183, 217, 243, 115, 90, 179, 161, 168, 183, 218, 117, 97, 85, 87, 123, 248, 137, 165, 197, 226, 188, 45, 140, 183, 220, 111, 246, 196, 212, 215, 220, 147, 173, 117, 79, 149, 109, 233, 239, 234, 205, 114, 73, 249, 234, 118, 255, 222, 18, 120, 131, 244, 127, 199, 118, 61, 242, 140, 69, 69, 42, 178, 147, 205, 57, 88, 230, 182, 178, 28, 140, 34, 71, 177, 100, 122, 206, 246, 91, 148, 215, 106, 205, 139, 127, 158, 218, 116, 87, 187, 171, 12, 53, 94, 233, 133, 150, 254, 102, 199, 7, 188, 236, 214, 239, 196, 47, 183, 102, 203, 137, 18, 246, 200, 214, 56, 178, 117, 14, 217, 26, 71, 182, 206, 33, 91, 227, 200, 214, 57, 100, 107, 212, 219, 215, 96, 52, 200, 214, 136, 221, 107, 148, 185, 227, 77, 234, 187, 145, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 168, 144, 45, 104, 252, 252, 252, 5, 41, 208, 105, 171, 3, 129, 183, 206, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 };
        string f = "137807871131026100001373726882000201000107820008211249183000111582716601742062823300041036577650017714311252975000911272891150014195001419511991111681000048173686584120942372182351491554820133209212696517419921320814013915392244073921001756241441751112552022322535699671466363128621713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171301021713010217130102171302026121715431127282112435388143111116227231214107126784153143217752052357761190203173223137576014357215222221322717114445168144451681444516825215410821715519299138213102122601831991252554511511524819018523515291190108174170962411541395882138419111318823018019420816710810813945261421721182153815613687122161165191217241147251292171781391782774871851901111661958912210921528793315991174776323689619488203164219162112441407626183215102216118165862911140692331777012729631832894109158162104109156821111112623323210213516719070146173119234441329478811105663202202246182150198213231704315724721419578187109159230432038318311423410985852471061773986235204176222141651107518352149117551071981671902262431599116117623714591238153815812811996715411518014515720620372312422011531265210551019116740218221232170183218102971981141032188217522919443109202252205158153250138143103431512491422382091914587121142246165209253613942252094711617039582041501232056511118110916724813723013229152551741011031792278395241241108197131412393918263159173172215115185139197120138791512525545912491872102717021766173215242104179227839524175178213187241218217246229137165631221571954718585173207827814413221720221523515229152551661012501635911921718163245211912295920923950231109111226124818322917078236224192157832531351081571694821916424625219118211215022615013180766328461071002344362255441591181001332371788243221721992471231646217718813210602398015713714231142212061541861712051791549898111459421772751191791392411691751845391105113135171203123173235115169157651451752402361793120031162394510661951034239808317924290114207246170981191116922121325016722917319743235182236109118496224521551022352042551772172217817441562012181344099216991714129138531093912380981572422231864718310027112292192501832172431159017916116818321811797858712324813716519722618845140183220111246196212215220147173117791491092332392342051147324923411825522218120131244127199118612421406969421781472055788230182178281403471177100122206246911482151062051391271582181168718717112539423313315025410219971882362142391964718310220313718246200214561781171421726711822063391227200214571001072122192159652200214136221107148185227772341871454516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444516814445168144451681444510425225225254120810517131291832060000736978681746696130";
        public byte[] imgTovara;

        public int id { get; set; }
        public string nameTovara { get; set; }
        public string idTovara { get; set; }
        public string sizeTovara { get; set; }
        public string colorTovara { get; set; }
        public string numbeTovara { get; set; }
        public string fio { get; set; }
        public string adres { get; set; }
        public string adresForUpdate { get; set; }
        public string adresComment { get; set; }
        public string tel { get; set; }
        public string ssylkaNaSosSeti { get; set; }
        public string articul { get; set; }
        public string priceTovara { get; set; }
        public string skidka { get; set; }
        public string comment { get; set; }
        public string otpKurer { get; set; }
        public string priceKur { get; set; }
        public string priceDeliveryPochta { get; set; }
        public string predOplata { get; set; }
        public string trek { get; set; }
        public string trekHyperlink { get; set; }
        public string index { get; set; }
        public string status { get; set; }
        public string nameOperatora { get; set; }
        public string dateZak { get; set; }

        BitmapImage image { get; set; }

        public BitmapImage imgForDataGrid
        {
            get { return this.image; }
        }

        public BitmapImage imageFunc(byte[] mass)
        {
            MemoryStream memorystream = new MemoryStream(mass, 0, mass.Length);
            memorystream.Position = 0;
            BitmapImage imgsource = new BitmapImage();
            imgsource.BeginInit();
            imgsource.CacheOption = BitmapCacheOption.OnLoad;
            imgsource.StreamSource = memorystream;
            imgsource.EndInit();
            return imgsource; // реальный Image
        }

        //Конструктор по умолчанию
        public DataGridZakaz() {
        }
        //это старый конструктор
        public DataGridZakaz(
            int id, 
            string fio, 
            string adres, 
            string adresComennt,
            string tel, 
            string ssylkaNaSosSeti,
             
            string articul,
            string skidka, 
            string comment, 
            string otpKurer, 
            string priceKur, 
            string predOplata, 
            string trek, 
            string status,
            string dateZak)
        {
            this.id = id;
            this.fio = fio;
            this.adresForUpdate = adres;
            this.adres = adres.Replace("$","");
            this.adresComment = adresComennt;
            this.tel = tel;
            this.ssylkaNaSosSeti = ssylkaNaSosSeti;
            this.articul = articul;
            this.skidka = articul;
            this.comment = comment;
            this.otpKurer = otpKurer;
            this.priceKur = priceKur;
            this.predOplata = predOplata;
            this.trek = trek;
            this.trekHyperlink = "https://www.pochta.ru/tracking#" + trek;
            this.status = status;
            this.dateZak = dateZak;
        }

        //Это новый конст 22 парам
        public DataGridZakaz(
            int id,
            string fio,
            string adres,
            string adresComennt,
            string tel,
            string ssylkaNaSosSeti,
            string idTovata,
            string nameTovara,
            string sizeTovara,
            string colorTovara,
            string numbeTovara,
            object imgTovara,
            string articul,
            string priceTovara,
            string skidka,
            string comment,
            string otpKurer,
            string priceKur,
            string pricePoch,
            string predOplata,
            string index,
            string trek,
            string status,
            string dateZak)
        {
            this.id = id;
            this.fio = fio;
            this.adresForUpdate = adres;
            this.adres = adres.Replace("$", "");
            this.adresComment = adresComennt;
            this.tel = tel;
            this.ssylkaNaSosSeti = ssylkaNaSosSeti;
            this.idTovara = idTovata;
            this.nameTovara = nameTovara;
            this.sizeTovara = sizeTovara;
            this.colorTovara = colorTovara;
            this.sizeTovara = sizeTovara;
            this.numbeTovara = numbeTovara;
            try
            {
                this.imgTovara = (byte[])imgTovara;
            }
            catch(InvalidCastException e) {
                this.imgTovara = this.defaultImg;
            }
            this.articul = articul;
            this.priceTovara = priceTovara;
            this.skidka = articul;
            this.comment = comment;
            this.otpKurer = otpKurer;
            this.priceKur = priceKur;
            this.priceDeliveryPochta = pricePoch;
            this.predOplata = predOplata;
            this.index = index;
            this.trek = trek;
            this.trekHyperlink = "https://www.pochta.ru/tracking#" + trek;
            this.status = status;
            this.dateZak = dateZak;
            this.image = imageFunc(this.imgTovara);
        }
    }
}
