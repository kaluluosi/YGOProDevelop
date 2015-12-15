
public class Constant{
	//代码
	public string Code;
	//值
	public int Value;
	//描述
	public string Description
	//分类
	public string Category
}

public class Constants:List<Constant>{
	
	public Constants(){
		
	}
	
	public Constants(string path){
		Load(path);
	}
	
	public Constants[string cate]{
		var query = from c in list
					where c.Category == cate
					select c;
		return query.ToList<Constant>();
	}	
	
	private string xmlPath;
		
	//记录constant数据是从哪个文件加载来的
	public string XmlPath{
		get{
			return xmlPath;
		}
		private set {
			xmlPath = value;
		}
	}
	
	//从xml配置文件加载constant数据
	public void Load(string path){
		//验证路径是否有效
		xmlPath = path;
		
		//xml反序列化操作
		list = #反序列化
	}
	
	//将constant保存到path
	public void Save(string path){
		//验证路径是否有效
		
		//xml序列化操作
		
	}
	
	//将constant保存回当初加载来的文件
	public void Save(){
		Save(xmlPath);
	}
}

