using System.IO;
using UnityEngine;

public class Picture : MonoBehaviour
{
    string _Path;
    public string _texname = "Pic.png";
    private Texture2D m_Tex;
    // Start is called before the first frame update
    void Start()
    {
        _Path = Application.dataPath + @"\texture";
        try
        {
            //加载
            LoadFromFile(_Path, _texname);
            //变换格式
            Sprite tempSprite = Sprite.Create(m_Tex, new Rect(0, 0, m_Tex.width, m_Tex.height), new Vector2(10, 10));
            this.GetComponent<MeshRenderer>().material.mainTexture = tempSprite.texture;
        }
        catch
        {
            return;
        }
    }
    private void LoadFromFile(string path, string _name)
    {
        m_Tex = new Texture2D(1, 1);
        m_Tex.LoadImage(ReadPNG(path + _name));
    }
    private byte[] ReadPNG(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, System.IO.FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        byte[] binary = new byte[fileStream.Length]; //创建文件长度的buffer
        fileStream.Read(binary, 0, (int)fileStream.Length);
        fileStream.Close();
        fileStream.Dispose();
        return binary;
    }
}
