using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditField : MonoBehaviour {
	const int EDIT_FIELD_WINDOW_ID = 0; //id окна поля редактора 
	const int ITEM_TEXTURE_ID = 1; //id окна с иконкой

	public float ButtonWidth = 40; //высота ячейки 
	public float ButtonHeight = 40; //ширина ячейки 
	
	int fieldRows = 10; //количество колонок 
	int fieldColumns = 20; //количество столбцов 
	Rect editFieldWindowRect = new Rect(10, 10, 
	                                    850, 600); //область окна
	Rect itemBoxRect = new Rect(); //область окна с изображением иконки 

	bool isDraggable; //возможно ли перемещение предмета 
	Item selectItem; //вспомогательная переменная куда заносим предмет уровня 
	Texture2D dragTexture; //текстура которая отображается при перетягивании предмета в поле уровня
	
	Dictionary<int, Item> EditorFieldPlayer = new Dictionary<int, Item>(); //словарь содержащий предметы конструктора 

	// Use this for initialization
	void Start () {
		//добавляем предметы в инвентарь 
		EditorFieldPlayer.Add(0, ItemData._ItemData.ItemGen(0)); 
		EditorFieldPlayer.Add(1, ItemData._ItemData.ItemGen(1)); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{ 
		editFieldWindowRect = GUI.Window(
			EDIT_FIELD_WINDOW_ID, 
			editFieldWindowRect, 
			firstInventory, 
			"LEVEL EDITOR FIELD"); //создаем окно 
		if (isDraggable) 
		{ 
			itemBoxRect = GUI.Window(
				ITEM_TEXTURE_ID, 
				new Rect(
					Event.current.mousePosition.x + 1, 
					Event.current.mousePosition.y + 1, 
					40, 
					40), 
				insert, 
				"", 
				"box"); 
			
		} 
	}

	//окно с изображением иконки 
	void insert(int id) 
	{ 
		GUI.BringWindowToFront(ITEM_TEXTURE_ID);//выводим на передний план окно с иконкой 
		GUI.DrawTexture(
			new Rect(
				Event.current.mousePosition.x, 
				Event.current.mousePosition.y, 
				40, 
				40), 
			dragTexture);//рисуем текстуру иконки 
	} 

	//окно с полем реактора
	void firstInventory(int id) 
	{ 
		for (int y = 0; y < fieldRows; y++) 
		{ 
			for (int x = 0; x < fieldColumns; x++) 
			{ 
				if (EditorFieldPlayer.ContainsKey(x + y * fieldColumns))//проверяем содеоржится ли ключ с данным значением 
				{ 
					if (GUI.Button(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), new GUIContent(EditorFieldPlayer[x + y * fieldColumns].Textura), "button")) 
					{ 
						if (!isDraggable) 
						{ 
							dragTexture = EditorFieldPlayer[x + y * fieldColumns].Textura;//присваиваем нашой текстуре которая должна отображаться при перетаскивании, текстуру предмета 
							isDraggable = true;//возможность перемещать предмет 
							selectItem = EditorFieldPlayer[x + y * fieldColumns];//присваиваем вспомогательной переменной наш предмет 
							EditorFieldPlayer.Remove(x + y * fieldColumns);//удаляем из словаря предмет 
						} 
					} 
				} 
				else 
				{ 
					if (isDraggable) 
					{ 
						if (GUI.Button(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), "", "button")) 
						{ 
							EditorFieldPlayer.Add(x + y * fieldColumns, selectItem);//добавляем предмет который перетаскиваем в словарь 
							//обнуляем переменные 
							isDraggable = false; 
							selectItem = null; 
						} 
					} 
					else 
					{ 
						//делаем ячейки не выделяемыми 
						GUI.Label(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), "", "button"); 
					} 
				} 
			} 
		} 
		GUI.DragWindow();
	}
}
