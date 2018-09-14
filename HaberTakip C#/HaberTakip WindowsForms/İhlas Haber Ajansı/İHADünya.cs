﻿using System.Collections.Generic;
using HtmlAgilityPack;

namespace HaberTakip_WindowsForms
{
    class İHADünya : SuperClass
    {
        public İHADünya(MainForm form, Kategoriler kategoriForm)
        {
            URL = "http://www.iha.com.tr/dunya/";
            YüklenenHaberler = new List<Haber>();
            KontrolHaberler = new List<Haber>();
            this.Form = form;
            this.KategoriForm = kategoriForm;
            IlkYükleme = false;
            XMLilkYükleme = false;
            PanelBaşlığı = "İHA/Dünya";
            XmlBaşlığı = "İHADünya";
            CheckBox = kategoriForm.ihaDünyaCheckBox;
        }

        public override void sonDakikaListesiniAl(HtmlDocument doc, List<Haber> liste)
        {
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div [@class= 'item']/a");

            foreach (HtmlNode node in nodes)
            {
                Haber haber = new Haber(Form);

                string link = node.Attributes[@"href"].Value;
                haber.HaberLinki = "http://www.iha.com.tr" + link;

                string başlık = node.Attributes[@"title"].Value;
                haber.HaberBaşlığı = başlık;

                HtmlNode imgNode = node.SelectSingleNode("./img");

                string imgURL = imgNode.Attributes[@"src"].Value;
                haber.FotoLinki = imgURL;

                
                liste.Add(haber);
            }
        }
    }
}
