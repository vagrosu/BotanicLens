using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem
{
    private string text = "";
    private int pos = 0;

	public InventoryItem(string text, int pos)
	{
		this.text = text;
        this.pos = pos;
	}

    public GameObject buildRectangle(string name, Color color, int x, int y, int sz)
    {
        GameObject item = new GameObject(name);
        Image panelImage = item.AddComponent<Image>();
        panelImage.color = color;

        RectTransform transformItem = item.GetComponent<RectTransform>();
        transformItem.sizeDelta = new Vector2(sz, sz);
        transformItem.anchoredPosition = new Vector2(x, y);

        return item;
    }

    public GameObject buildCube(Color color, int x, int y, int z, int szX, int szY, int szZ)
    {
        GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Material cubeMaterial = new Material(Shader.Find("Standard")); 
        cubeMaterial.color = color;
        Renderer cubeRenderer = cubeObject.GetComponent<Renderer>();

        if (cubeRenderer != null)
        {
            cubeRenderer.material = cubeMaterial;
        }

        cubeObject.transform.localScale = new Vector3(szX, szY, szZ);
        cubeObject.transform.position = new Vector3(x, y, z);

        return cubeObject;
    }

    public GameObject createText(string text, Color textColor, int fontSize)
    {
        GameObject textObject = new GameObject(text);
        TextMeshProUGUI actualText = textObject.AddComponent<TextMeshProUGUI>();
        actualText.text = text;
        actualText.fontSize = fontSize;
        actualText.color = textColor;
        return textObject;
    }

    public GameObject loadImage(string path)
    {
        Debug.Log(path);
        GameObject imageObject = new GameObject("Image");
        Sprite spriteImage = Resources.Load<Sprite>(path);
        SpriteRenderer spriteRenderer = imageObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = imageObject.AddComponent<SpriteRenderer>();
        }
        spriteRenderer.sortingOrder = 1;
        spriteRenderer.sprite = spriteImage;

        return imageObject;
    }

    public GameObject createButton(string text, int posX, int posY)
    {
        GameObject buttonObject = new GameObject("Button");
        Button button = buttonObject.AddComponent<Button>();
        GameObject buttonRect = this.buildCube(Color.green, posX, posY + 50, 0, 100, 100, 600);
        button.transform.SetParent(buttonObject.transform);
        buttonRect.transform.SetParent(buttonObject.transform);

        return buttonObject;
    }

    public GameObject spawnItem(Transform parent)
	{
        int posX = 300 + 700 * (pos % 2);
        int posY = -700 - Convert.ToInt32(pos / 2) * 800;


        GameObject table = this.buildCube(Color.white, posX, posY, 0, 500, 100, 500);
        table.transform.localPosition = new Vector3(posX, posY, 0);
        table.transform.localScale = new Vector3(500, 200, 500);
        table.transform.SetParent(parent);

        GameObject button = this.createButton("*", posX + 100, posY - 100);
        button.transform.SetParent(table.transform);


        return table;
    }

}

