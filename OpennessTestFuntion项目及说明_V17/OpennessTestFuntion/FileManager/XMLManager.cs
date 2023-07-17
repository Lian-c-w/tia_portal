using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.IO;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering;

namespace FileManager
{
    public class TankType
    {
        public ProgressInformation MyprogressInformation { get; set; }
        public string Name { get; set; }
        public string BlockName { get; set; }
        public string TypeName { get; set; }
        public IDBBlockType idbTank { get; set; } = new IDBBlockType();
        public string BlockPath { get; set; }//罐路径
        public void ImportBlockFromXML(PlcBlockGroup blockGroup)
        {
            //PlcBlockUserGroup userGroup = blockGroup.Groups.Create("罐控制背景DB");
            idbTank.Path = ModifyXML(BlockPath + "IDB_Tank.xml");
            idbTank.MyprogressInformation = MyprogressInformation;
            idbTank.ImportBlockFromXML(blockGroup);
        }
        private string ModifyXML(string path)
        {
            string modifiedFile = Path.GetTempFileName();
            XElement xml = XElement.Load(path);
            XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

            xml = idbTank.ModifyXML(path, this);

            xml.Save(modifiedFile);
            return modifiedFile;
        }
    }
    public class Workshop
    {
        public ProgressInformation MyprogressInformation { get; set; }
        public List<TankType> Tanks { get; set; } = new List<TankType>();
        public string Name { get; set; }
        public string BlockName { get; set; } //调用功能块的名称
        public FBBlockType fbWorkShop { get; set; } = new FBBlockType();
        public IDBBlockType idbWorkShop { get; set; } = new IDBBlockType();
        public FCBlockType fcWorkShop { get; set; } = new FCBlockType();
        public string BlockPath { get; set; }//车间级路径

        //public DirectoryInfo Path { get; set; }
        public void Add(TankType tt)
        {
            Tanks.Add(tt);
        }
        public void ImportBlockFromXML(PlcBlockGroup blockGroup)
        {
            //PlcBlockUserGroup userGroup = blockGroup.Groups.Create(Name);
            //fbWorkShop.Path = BlockPath + "FB_Workshop.xml";//为功能块添加路径
            fbWorkShop.Path = ModifyXML(BlockPath + "FB_Workshop.xml");
            fbWorkShop.MyprogressInformation = MyprogressInformation;
            fbWorkShop.ImportBlockFromXML(blockGroup);

            idbWorkShop.Path = ModifyXML(BlockPath + "IDB_Workshop.xml");
            //idbWorkShop.Path = BlockPath + "IDB_Workshop.xml";
            idbWorkShop.MyprogressInformation = MyprogressInformation;
            idbWorkShop.ImportBlockFromXML(blockGroup);

            fcWorkShop.Path = ModifyXML(BlockPath + "FC_Workshop.xml");
            fcWorkShop.MyprogressInformation = MyprogressInformation;
            fcWorkShop.ImportBlockFromXML(blockGroup);

        }
        private string ModifyXML(string path)
        {
            string modifiedFile = Path.GetTempFileName();
            XElement xml = XElement.Load(path);
            XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

            string  BlockTypeName = null;
            JudgeBlockType(xml, out BlockTypeName);

            if (BlockTypeName == "FB")
            {
                xml = fbWorkShop.ModifyXML(path, this);
            }
            else if (BlockTypeName == "FC")
            {
                xml = fcWorkShop.ModifyXML(path,this);
            }
            else if (BlockTypeName == "InstanceDB")
            {
                xml = idbWorkShop.ModifyXML(path, this);
            }

            xml.Save(modifiedFile);
            return modifiedFile;            
        }
        private void JudgeBlockType(XElement xml, out string TypeName)
        {
            if (xml.Descendants("SW.Blocks.FB").Count() > 0)
            {
                TypeName = "FB";
            }
            else if (xml.Descendants("SW.Blocks.FC").Count() > 0)
            {
                TypeName = "FC";
            }
            else if (xml.Descendants("SW.Blocks.InstanceDB").Count() > 0)
            {
                TypeName = "InstanceDB";
            }
            else
            {
                TypeName = null;
            }           
        }

    }
    public class Factory
    {
        public ProgressInformation MyprogressInformation { get; set; }
        public List<Workshop> Workshops { get; set; } = new List<Workshop>();
        public string Name { get; set; }
        public string BlockPath { get; set; }//工厂级路径
        public OBBlockType Main { get; set; } = new OBBlockType();//工厂级OB1
        public OBBlockType StartUp { get; set; } = new OBBlockType();//工厂级OB100      
        public void Add(Workshop ws)
        {
            Workshops.Add(ws);
        }
        /// <summary>
        /// 统计元素个数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int i = 0;
            i++;//计数main块
            i++;//计数OB100块
            foreach(Workshop ws in Workshops)
            {
                i++;//计数车间目录
                i++;//计数FC块
                ws.fcWorkShop.Number = i.ToString();
                ws.fcWorkShop.Name = ws.Name;
                i++;//计数workshop块；
                ws.fbWorkShop.Number = i.ToString();
                ws.fbWorkShop.Name = ws.Name;
                i ++;//计数背景DB
                ws.idbWorkShop.Number = i.ToString();
                ws.idbWorkShop.Name = ws.Name;
                i++;//计数罐监控目录
                foreach(TankType tt in ws.Tanks)
                {
                    i++;//计数Tank的DB块
                    tt.idbTank.Number = i.ToString();
                    tt.idbTank.Name = tt.Name;
                }
            }
            return i;
        }
        public void Reset()
        {
            Name = "";            
            while(Workshops.Count>0)
            {
                Workshops.RemoveAt(0);
            }
        }
        public void ImportBlockFromXML(PlcBlockGroup blockGroup)
        {
            
            Main.Path = ModifyXML(BlockPath + "Main.xml");//根据工厂参数修改XML
            Main.Name = "Main";
            Main.MyprogressInformation = MyprogressInformation;
            Main.ImportBlockFromXML(blockGroup);//导入XML
            
            StartUp.Path = ModifyXML(BlockPath + "StartUp.xml");
            StartUp.Name = "StartUp";
            StartUp.MyprogressInformation = MyprogressInformation;
            StartUp.ImportBlockFromXML(blockGroup);
            //导入车间块
            foreach(Workshop workshop in Workshops)
            {
                workshop.MyprogressInformation = MyprogressInformation;
                workshop.BlockPath = BlockPath;//将块路径传入车间对象
                PlcBlockUserGroup userGroup = blockGroup.Groups.Create(workshop.Name);
                MyprogressInformation.ProgressBarAdd();
                MyprogressInformation.TextBoxAdd("文件夹 "+ workshop.Name + " 成功建立");
                workshop.ImportBlockFromXML(userGroup);
                PlcBlockUserGroup subuserGroup = userGroup.Groups.Create("罐控制背景DB");
                MyprogressInformation.ProgressBarAdd();
                MyprogressInformation.TextBoxAdd("文件夹  罐控制背景DB  成功建立");
                foreach (TankType tank in workshop.Tanks)
                {
                    tank.MyprogressInformation = MyprogressInformation;
                    //PlcBlockUserGroup subuserGroup = userGroup.Groups.Create("罐控制背景DB");
                    tank.BlockPath = BlockPath;//将块路径传入罐对象
                    tank.ImportBlockFromXML(subuserGroup);
                }
            }
            
        }
        private string ModifyXML(string path)
        {
            string modifiedFile = Path.GetTempFileName();
            XElement xmlmodule = XElement.Load(path);
            XElement xml = XElement.Load(path);
            XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

            xmlmodule = xmlmodule.Descendants("SW.Blocks.CompileUnit").First();//获取调用单元模块

            xml = ClearCall(xml);//清空调用

            var network1 = xml.Descendants("MultilingualText").FirstOrDefault(el => el.Attribute("ID").Value == "12");

            for (int i = 0; i < Workshops.Count; i++)
            {
                var network = xmlmodule;

                if (i == 0)
                {
                    network = xmlmodule.Descendants(ns + "CallInfo").First();

                    if (network.Attribute("BlockType").Value == "FB")
                    {
                        network.SetAttributeValue("Name", "FB_"+ Workshops[i].Name);
                        network = network.Descendants(ns + "Component").First();
                        network.SetAttributeValue("Name", "IDB_"+ Workshops[i].Name);
                    }
                    else if (network.Attribute("BlockType").Value == "FC")
                    {
                        network.SetAttributeValue("Name", "FC_"+ Workshops[i].Name);
                    }
                    network1.AddBeforeSelf(xmlmodule);
                }
                else
                {
                    xmlmodule.SetAttributeValue("ID", (i * 10 + 100).ToString());

                    network = xmlmodule.Descendants(ns + "CallInfo").First();
                    if (network.Attribute("BlockType").Value == "FB")
                    {
                        network.SetAttributeValue("Name", "FB_" + Workshops[i].Name);
                        network = network.Descendants(ns + "Component").First();
                        network.SetAttributeValue("Name", "IDB_" + Workshops[i].Name);
                    }
                    else if (network.Attribute("BlockType").Value == "FC")
                    {
                        network.SetAttributeValue("Name", "FC_" + Workshops[i].Name);
                    }

                    network = xmlmodule.Descendants("MultilingualText").ElementAt(0);
                    network.SetAttributeValue("ID", (i * 10 + 101).ToString());
                    network = network.Descendants("MultilingualTextItem").First();
                    network.SetAttributeValue("ID", (i * 10 + 102).ToString());
                    network = xmlmodule.Descendants("MultilingualText").ElementAt(1);
                    network.SetAttributeValue("ID", (i * 10 + 103).ToString());
                    network = network.Descendants("MultilingualTextItem").First();
                    network.SetAttributeValue("ID", (i * 10 + 104).ToString());

                    network1.AddBeforeSelf(xmlmodule);
                }
            }
            xml.Save(modifiedFile);
            return modifiedFile;
        }//根据工厂参数修改XML文件
        private XElement ClearCall(XElement xml)
        {
            while (xml.Descendants("SW.Blocks.CompileUnit").Count() != 0)
            {
                var network = xml.Descendants("SW.Blocks.CompileUnit").First();
                network.Remove();
            }
            return xml;
        }

    }
    public class BasicBlockType//块基本类型
    {
        public ProgressInformation MyprogressInformation { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }

        public void ImportBlockFromXML(PlcBlockGroup blockGroup)
        {
            FileInfo fileInfo = new FileInfo(Path);
            blockGroup.Blocks.Import(fileInfo, ImportOptions.Override);
            MyprogressInformation.ProgressBarAdd();
            MyprogressInformation.TextBoxAdd("块 "+ Name + " 成功添加");
        }
        protected XElement ClearCall(XElement xml)
        {
            while (xml.Descendants("SW.Blocks.CompileUnit").Count() != 0)
            {
                var network = xml.Descendants("SW.Blocks.CompileUnit").First();
                network.Remove();
            }
            return xml;
        }
    }
    public class FCBlockType:BasicBlockType//FC块类型
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public string InOut { get; set; }

        public XElement ModifyXML(string path, Workshop workshop)
        {
            XElement xml = XElement.Load(path);
            XElement xmlmodule = XElement.Load(path);

            XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

            xmlmodule = xmlmodule.Descendants("SW.Blocks.CompileUnit").First();//获取调用单元模块

            xml = ClearCall(xml);//清空调用
            xml = ChangeNameAndNumber(xml, workshop);

            var network1 = xml.Descendants("MultilingualText").FirstOrDefault(el => el.Attribute("ID").Value == "12");

            for (int i = 0; i < workshop.Tanks.Count; i++)
            {
                var network = xmlmodule;

                if (i == 0)
                {
                    network = xmlmodule.Descendants(ns + "Access").FirstOrDefault(el => el.Attribute("UId").Value == "21");
                    network = network.Descendants(ns + "Component").First();
                    network.SetAttributeValue("Name", workshop.Tanks[i].TypeName + "Level");

                    network = xmlmodule.Descendants(ns + "Access").FirstOrDefault(el => el.Attribute("UId").Value == "22");
                    network = network.Descendants(ns + "Component").First();
                    network.SetAttributeValue("Name", "IDB_"+ workshop.Tanks[i].Name);

                    network1.AddBeforeSelf(xmlmodule);
                }
                else
                {
                    xmlmodule.SetAttributeValue("ID", (i * 10 + 100).ToString());


                    network = xmlmodule.Descendants(ns + "Access").FirstOrDefault(el => el.Attribute("UId").Value == "21");
                    network = network.Descendants(ns + "Component").First();
                    network.SetAttributeValue("Name", workshop.Tanks[i].TypeName + "Level");

                    network = xmlmodule.Descendants(ns + "Access").FirstOrDefault(el => el.Attribute("UId").Value == "22");
                    network = network.Descendants(ns + "Component").First();
                    network.SetAttributeValue("Name", "IDB_" + workshop.Tanks[i].Name);

                    network = xmlmodule.Descendants("MultilingualText").ElementAt(0);
                    network.SetAttributeValue("ID", (i * 10 + 101).ToString());
                    network = network.Descendants("MultilingualTextItem").First();
                    network.SetAttributeValue("ID", (i * 10 + 102).ToString());
                    network = xmlmodule.Descendants("MultilingualText").ElementAt(1);
                    network.SetAttributeValue("ID", (i * 10 + 103).ToString());
                    network = network.Descendants("MultilingualTextItem").First();
                    network.SetAttributeValue("ID", (i * 10 + 104).ToString());

                    network1.AddBeforeSelf(xmlmodule);
                }
            }
            return xml;
        }
        private  XElement ChangeNameAndNumber(XElement xml, Workshop workshop)
        {
            XElement attributeList = xml.Descendants("AttributeList").FirstOrDefault();
            XElement name = xml.Descendants("Name").FirstOrDefault();
            name.SetValue("FC_"+ workshop.fcWorkShop.Name);
            XElement number = xml.Descendants("Number").FirstOrDefault();
            number.SetValue(workshop.fcWorkShop.Number);
            return xml;
        }
    }
    public class FBBlockType:FCBlockType //FB块类型
    {
        public string Static { get; set; }
        public new XElement ModifyXML(string path, Workshop workshop)
        {

            XElement xml = XElement.Load(path);
            XElement xmlmodule = XElement.Load(path);

            XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

            xmlmodule = xmlmodule.Descendants("SW.Blocks.CompileUnit").First();//获取调用单元模块

            xml = ClearCall(xml);//清空调用
            xml = ChangeNameAndNumber(xml, workshop);//修改块名称和块编号

            var network1 = xml.Descendants("MultilingualText").FirstOrDefault(el => el.Attribute("ID").Value == "12");

            for (int i = 0; i < workshop.Tanks.Count; i++)
            {
                var network = xmlmodule;

                if (i == 0)
                {
                    network = xmlmodule.Descendants(ns + "CallInfo").First();

                    network.SetAttributeValue("Name", "Tank");
                    network = network.Descendants(ns + "Component").First();
                    network.SetAttributeValue("Name", "IDB_" + workshop.Tanks[i].Name);

                    network1.AddBeforeSelf(xmlmodule);
                }
                else
                {
                    xmlmodule.SetAttributeValue("ID", (i * 10 + 100).ToString());

                    network = xmlmodule.Descendants(ns + "CallInfo").First();

                    network.SetAttributeValue("Name", "Tank");
                    network = network.Descendants(ns + "Component").First();
                    network.SetAttributeValue("Name", "IDB_" + workshop.Tanks[i].Name);

                    network = xmlmodule.Descendants("MultilingualText").ElementAt(0);
                    network.SetAttributeValue("ID", (i * 10 + 101).ToString());
                    network = network.Descendants("MultilingualTextItem").First();
                    network.SetAttributeValue("ID", (i * 10 + 102).ToString());
                    network = xmlmodule.Descendants("MultilingualText").ElementAt(1);
                    network.SetAttributeValue("ID", (i * 10 + 103).ToString());
                    network = network.Descendants("MultilingualTextItem").First();
                    network.SetAttributeValue("ID", (i * 10 + 104).ToString());

                    network1.AddBeforeSelf(xmlmodule);
                }
            }
            return xml;
        }
        private XElement ChangeNameAndNumber(XElement xml, Workshop workshop)
        {
            XElement attributeList = xml.Descendants("AttributeList").FirstOrDefault();
            XElement name = xml.Descendants("Name").FirstOrDefault();
            name.SetValue("FB_"+ workshop.fbWorkShop.Name);
            XElement number = xml.Descendants("Number").FirstOrDefault();
            number.SetValue(workshop.fbWorkShop.Number);
            return xml;
        }
    }
    public class DBBlockType:BasicBlockType//DB块类型
    {

    }
    public class IDBBlockType:BasicBlockType//背景DB块类型
    {
        public XElement ModifyXML(string path, Workshop workshop)
        {
            XElement xml = XElement.Load(path);
            xml = ChangeNameAndNumber(xml, workshop);
            return xml;
        }
        public XElement ModifyXML(string path, TankType tank)
        {
            XElement xml = XElement.Load(path);
            xml = ChangeNameAndNumber(xml, tank);
            return xml;
        }
        private XElement ChangeNameAndNumber(XElement xml, Workshop workshop)
        {
            XElement attributeList = xml.Descendants("AttributeList").FirstOrDefault();
            XElement instanceOfName = xml.Descendants("InstanceOfName").FirstOrDefault();
            instanceOfName.SetValue("FB_" + workshop.idbWorkShop.Name);
            XElement name = xml.Descendants("Name").FirstOrDefault();
            name.SetValue("IDB_"+ workshop.idbWorkShop.Name);
            XElement number = xml.Descendants("Number").FirstOrDefault();
            number.SetValue(workshop.idbWorkShop.Number);
            return xml;
        }
        private XElement ChangeNameAndNumber(XElement xml, TankType tank)
        {
            XElement attributeList = xml.Descendants("AttributeList").FirstOrDefault();
            XElement instanceOfName = xml.Descendants("InstanceOfName").FirstOrDefault();
            instanceOfName.SetValue("Tank");
            XElement name = xml.Descendants("Name").FirstOrDefault();
            name.SetValue("IDB_" + tank.idbTank.Name);
            XElement number = xml.Descendants("Number").FirstOrDefault();
            number.SetValue(tank.idbTank.Number);
            return xml;
        }
    }
    public class OBBlockType:BasicBlockType
    {      

       
    }
    //public class XMLManager
    //{
    //    static public string ModifyFile(Factory ft, FileInfo fi)
    //    {
    //        string modifiedFile = Path.GetTempFileName();
    //        XElement xml = XElement.Load(fi.FullName);            
    //        XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";            
    //        if (ft.Workshops.Count < 2)
    //        {
    //            for (int i = 0; i < xml.Descendants("SW.Blocks.CompileUnit").Count(); i++)
    //            {
    //                var network = xml.Descendants("SW.Blocks.CompileUnit").ElementAt(i);
    //                if (network != null)
    //                {
    //                    bool flag = false;
    //                    //删除不存在的程序调用
    //                    foreach (Workshop ws in ft.Workshops)
    //                    {
    //                        string subws = ws.BlockName.Substring(0, 9);
    //                        if(network.Descendants(ns + "CallInfo").FirstOrDefault(el => el.Attribute("Name").Value.Substring(0,9) == subws)!=null)
    //                        {
    //                            flag = flag || true;
    //                        }
    //                    }
    //                    if (!flag)
    //                    {
    //                        network.Remove();
    //                        //i--;
    //                    }                                            
    //                }
    //            }
    //        }
    //       xml.Save(modifiedFile);
    //       return modifiedFile;
    //    }
    //    static public string ModifyFile(Workshop ws, FileInfo fi)
    //    {
    //        string modifiedFile = Path.GetTempFileName();
    //        XElement xml = XElement.Load(fi.FullName);            
    //        XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";            
    //        if (ws.Tanks.Count < 2)
    //        {
    //            for (int i = 0; i < xml.Descendants("SW.Blocks.CompileUnit").Count(); i++)
    //            {
    //                var network = xml.Descendants("SW.Blocks.CompileUnit").ElementAt(i);
    //                if (network != null)
    //                {
    //                    bool flag = false;
    //                    //删除不存在的程序调用
    //                    foreach (TankType tt in ws.Tanks)
    //                    {
    //                        if(network.Descendants(ns + "Component").FirstOrDefault(el => el.Attribute("Name").Value == tt.BlockName)!=null)
    //                        {
    //                            flag = flag || true;
    //                        }                            
    //                    }
    //                    if (!flag)
    //                    {
    //                        network.Remove();
    //                        //i--;
    //                    }                       
    //                }
    //            }
    //        }
    //        xml.Save(modifiedFile);
    //        return modifiedFile;
    //    }
    //    /// <summary>
    //    /// 加法修改XML
    //    /// </summary>
    //    /// <param name="ft"></param>
    //    /// <param name="fi"></param>
    //    /// <returns></returns>
    //    static public string ModifyFileAdd(Factory ft, FileInfo fi)
    //    {
    //        string modifiedFile = Path.GetTempFileName();
    //        XElement xmlmodule = XElement.Load(fi.FullName);
    //        XElement xml = XElement.Load(fi.FullName);            
    //        XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

    //        xmlmodule = xmlmodule.Descendants("SW.Blocks.CompileUnit").First();//获取调用单元模块
       
    //        xml = ClearCall(xml);//清空调用

    //        var network1 = xml.Descendants("MultilingualText").FirstOrDefault(el => el.Attribute("ID").Value == "12");

    //        for (int i =0;i< ft.Workshops.Count;i++)
    //        {
    //            var network = xmlmodule;

    //            if(i==0)
    //            {
    //                network = xmlmodule.Descendants(ns + "CallInfo").First();
                  
    //                if (network.Attribute("BlockType").Value == "FB")
    //                {
    //                    network.SetAttributeValue("Name", ft.Workshops[i].BlockName);
    //                    network = network.Descendants(ns + "Component").First();
    //                    network.SetAttributeValue("Name", ft.Workshops[i].BlockName + "_DB");
    //                }
    //                else if(network.Attribute("BlockType").Value == "FC")
    //                {
    //                    network.SetAttributeValue("Name", ft.Workshops[i].BlockName + "_FC");
    //                }
    //                network1.AddBeforeSelf(xmlmodule);                   
    //            }
    //            else
    //            {
    //                xmlmodule.SetAttributeValue("ID", (i*10+100).ToString());

    //                network = xmlmodule.Descendants(ns + "CallInfo").First();
    //                if (network.Attribute("BlockType").Value == "FB")
    //                {
    //                    network.SetAttributeValue("Name", ft.Workshops[i].BlockName);
    //                    network = network.Descendants(ns + "Component").First();
    //                    network.SetAttributeValue("Name", ft.Workshops[i].BlockName + "_DB");
    //                }
    //                else if(network.Attribute("BlockType").Value == "FC")
    //                {
    //                    network.SetAttributeValue("Name", ft.Workshops[i].BlockName + "_FC");
    //                }

    //                network = xmlmodule.Descendants("MultilingualText").ElementAt(0);
    //                network.SetAttributeValue("ID", (i * 10 + 101).ToString());
    //                network = network.Descendants("MultilingualTextItem").First();
    //                network.SetAttributeValue("ID", (i * 10 + 102).ToString());
    //                network = xmlmodule.Descendants("MultilingualText").ElementAt(1);
    //                network.SetAttributeValue("ID", (i * 10 + 103).ToString());
    //                network = network.Descendants("MultilingualTextItem").First();
    //                network.SetAttributeValue("ID", (i * 10 + 104).ToString());

    //                network1.AddBeforeSelf(xmlmodule);
    //            }                
    //        }
    //        xml.Save(modifiedFile);
    //        return modifiedFile;            
    //    }
    //    static public string ModifyFileAdd(Workshop ws, FileInfo fi)
    //    {
    //        string modifiedFile = Path.GetTempFileName();           
    //        XElement xml = XElement.Load(fi.FullName);
    //        XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

    //        BlockType bt = new BlockType();
            
    //        JudgeBlockType(xml, bt);

    //        //if (bt.TypeName == "FB")
    //        //{
    //        //    xml = ModifyFB(fi, ws);
    //        //}
    //        //else if(bt.TypeName == "FC")
    //        //{
    //        //    xml = ModifyFC(fi, ws);
    //        //}
           
    //        xml.Save(modifiedFile);
    //        return modifiedFile;
    //    }
    //    //清空调用
    //    static XElement ClearCall(XElement xml)
    //    {
    //        while (xml.Descendants("SW.Blocks.CompileUnit").Count() != 0)
    //        {
    //            var network = xml.Descendants("SW.Blocks.CompileUnit").First();
    //            network.Remove();
    //        }
    //        return xml;
    //    }
    //    /// <summary>
    //    /// 判断块类型（FB，FC，DB）
    //    /// </summary>
    //    /// <param name="xml"></param>
    //    /// <returns></returns>
    //    static void JudgeBlockType(XElement xml,BlockType bt)
    //    {
    //        //if(xml.Descendants("SW.Blocks.FB").Count()>0)
    //        //{
    //        //    bt.TypeName = "FB";
    //        //}
    //        //else if(xml.Descendants("SW.Blocks.FC").Count() > 0)
    //        //{
    //        //    bt.TypeName = "FC";     
    //        //}
    //        //else if(xml.Descendants("SW.Blocks.InstanceDB").Count() > 0)
    //        //{
    //        //    bt.TypeName = "InstanceDB";
    //        //}
    //        //var network = xml.Descendants("MultilingualText").First();
    //        //xml.if
    //    }
    //    static XElement ModifyFC(FileInfo fi, Workshop ws)
    //    {
    //        XElement xml = XElement.Load(fi.FullName);
    //        XElement xmlmodule = XElement.Load(fi.FullName);

    //        XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

    //        xmlmodule = xmlmodule.Descendants("SW.Blocks.CompileUnit").First();//获取调用单元模块

    //        xml = ClearCall(xml);//清空调用

    //        var network1 = xml.Descendants("MultilingualText").FirstOrDefault(el => el.Attribute("ID").Value == "12");

    //        for (int i = 0; i < ws.Tanks.Count; i++)
    //        {
    //            var network = xmlmodule;

    //            if (i == 0)
    //            {
    //                network = xmlmodule.Descendants(ns + "Access").FirstOrDefault(el => el.Attribute("UId").Value == "21");
    //                network = network.Descendants(ns + "Component").First();
    //                network.SetAttributeValue("Name", ws.Tanks[i].TypeName + "Level");

    //                network = xmlmodule.Descendants(ns + "Access").FirstOrDefault(el => el.Attribute("UId").Value == "22");
    //                network = network.Descendants(ns + "Component").First();
    //                network.SetAttributeValue("Name", ws.Tanks[i].BlockName);

    //                network1.AddBeforeSelf(xmlmodule);
    //            }
    //            else
    //            {
    //                xmlmodule.SetAttributeValue("ID", (i * 10 + 100).ToString());

                  
    //                network = xmlmodule.Descendants(ns + "Access").FirstOrDefault(el => el.Attribute("UId").Value == "21");
    //                network = network.Descendants(ns + "Component").First();
    //                network.SetAttributeValue("Name", ws.Tanks[i].TypeName + "Level");

    //                network = xmlmodule.Descendants(ns + "Access").FirstOrDefault(el => el.Attribute("UId").Value == "22");
    //                network = network.Descendants(ns + "Component").First();
    //                network.SetAttributeValue("Name", ws.Tanks[i].BlockName);

    //                network = xmlmodule.Descendants("MultilingualText").ElementAt(0);
    //                network.SetAttributeValue("ID", (i * 10 + 101).ToString());
    //                network = network.Descendants("MultilingualTextItem").First();
    //                network.SetAttributeValue("ID", (i * 10 + 102).ToString());
    //                network = xmlmodule.Descendants("MultilingualText").ElementAt(1);
    //                network.SetAttributeValue("ID", (i * 10 + 103).ToString());
    //                network = network.Descendants("MultilingualTextItem").First();
    //                network.SetAttributeValue("ID", (i * 10 + 104).ToString());

    //                network1.AddBeforeSelf(xmlmodule);
    //            }
    //        }
    //        return xml;
    //    }
    //    static XElement ModifyFB(FileInfo fi, Workshop ws)
    //    {
            
    //        XElement xml = XElement.Load(fi.FullName);
    //        XElement xmlmodule = XElement.Load(fi.FullName);
            
    //        XNamespace ns = "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4";

    //        xmlmodule = xmlmodule.Descendants("SW.Blocks.CompileUnit").First();//获取调用单元模块

    //        xml = ClearCall(xml);//清空调用

    //        var network1 = xml.Descendants("MultilingualText").FirstOrDefault(el => el.Attribute("ID").Value == "12");

    //        for (int i = 0; i < ws.Tanks.Count; i++)
    //        {
    //            var network = xmlmodule;

    //            if (i == 0)
    //            {
    //                network = xmlmodule.Descendants(ns + "CallInfo").First();
                                       
    //                    network.SetAttributeValue("Name", ws.Tanks[i].BlockName.Substring(0, 4));
    //                    network = network.Descendants(ns + "Component").First();
    //                    network.SetAttributeValue("Name", ws.Tanks[i].BlockName );
                                    
    //                network1.AddBeforeSelf(xmlmodule);
    //            }
    //            else
    //            {
    //                xmlmodule.SetAttributeValue("ID", (i * 10 + 100).ToString());

    //                network = xmlmodule.Descendants(ns + "CallInfo").First();
                  
    //                    network.SetAttributeValue("Name", ws.Tanks[i].BlockName.Substring(0, 4));
    //                    network = network.Descendants(ns + "Component").First();
    //                    network.SetAttributeValue("Name", ws.Tanks[i].BlockName );                                

    //                network = xmlmodule.Descendants("MultilingualText").ElementAt(0);
    //                network.SetAttributeValue("ID", (i * 10 + 101).ToString());
    //                network = network.Descendants("MultilingualTextItem").First();
    //                network.SetAttributeValue("ID", (i * 10 + 102).ToString());
    //                network = xmlmodule.Descendants("MultilingualText").ElementAt(1);
    //                network.SetAttributeValue("ID", (i * 10 + 103).ToString());
    //                network = network.Descendants("MultilingualTextItem").First();
    //                network.SetAttributeValue("ID", (i * 10 + 104).ToString());

    //                network1.AddBeforeSelf(xmlmodule);
    //            }
    //        }
    //        return xml;
    //    }





    //}
}
