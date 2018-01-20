#include<stdio.h>
#include<stdlib.h>
#include<Windows.h>
#include<MMSystem.h>
#include<time.h>
#pragma comment(lib,"Winmm.lib")
/***********************************************     数据定义   ****************************************************/
typedef struct Snakenode {
	int column;                                                                /*存储蛇节点所在列*/
	int Line;                                                                  /*存储蛇节点所在行*/
	int Statu;                                                                 /*表示此节是否存在 为1则打印这一节到界面 否则 不打印*/
	char Direction;                                                            /*表示蛇的方向，便于得到蛇的最后一节的方向*/
} Snakes;                                                                      /*蛇的节点*/
typedef struct food
{
	int Line;                                                                   /*存储食物所在行*/
	int Column;                                                                 /*存储食物所在列*/
	int status;                                                                 /*表示食物的状态，初次生成食物时，判断其状态*/
} Food;																	        /*，为0则生成食物的坐标*/
			                                                                    /* ，否则不生成 每次蛇吃掉食物，则设置食物状态为0*/
typedef struct Mapspot
{
	int line;
	int Column;
} Mapspots;
/******************************                    界面设计函数                  ********************************/
void InitialInterface();                                                         /*初始游戏界面          */
int ClassicModeInterface();                                                      /*经典模式下难度选择界面*/
void AdvancedModeInterface();                                                    /*进阶模式下难度选择界面*/
void PersonalRecordView();                                                       /*个人记录查看*/
void ReadPersonalRecord();                                                       /*从文件中读出个人记录*/
void WritePersonalRecord();                                                      /*将新的个人记录写入文件*/
void HelpDocumentation();                                                        /*游戏操作说明*/
/****************************************************************************************************************/

/*****************************                     辅助功能函数                  ********************************/
void Loop(int int_loop, char Str[20]);                                           /*用于某些字符的循环输出*/
void GPS(int x, int y);                                                          /*用于定位光标位置*/
int GetRandomValue(int int_Max);                                                 /*产生随机数*/
/****************************************************************************************************************/
/*                                      ■△▲☆★○●◎◇◆□〓→←↑↓♂♀                                    */
/*****************************                     游戏运行函数                  ********************************/
void ClassicModeGameStart(int int_Difficulty);                                                      /*运行经典模式下的游戏*/
void GameMapPrint(Snakes *snake,Food *foods);                                                       /*打印地图，地图数据，若为，经典模式则返回地图数据*/
void AdvancedModeBronzeGameMapPrint(Snakes *snake, Food *foods);                                    /*打印 进阶模式下的初级玩家游戏地图*/
void AdvancedModeProductFood(Snakes *snake, Food *foods, int int_Mode);								/*产生 进阶模式下的  食物初次位置函数*/
void AdvancedModeProductFirst(Snakes *snake,int int_Mode);                                          /*产生 进阶模式下的  蛇初次位置函数*/
void AdvancedCollisionCheck(Snakes *snake, int int_difficulty);                                     /*进阶模式下的 碰撞检测*/
void AdvancedModeHellGameMapPrint(Snakes *snake, Food *foods);                                      /*打印进阶模式下的中级玩家游戏地图*/
void AdvancedModeHeavenGameMapPrint(Snakes *snake, Food *foods);                                    /*打印进阶模式下的高级玩家游戏地图*/
void GameInterfacePrint(Snakes *snake, Snakes snaketail, Food *foods, int int_SleepTime);          /*打印蛇的移动*/
void ProductFood(Snakes *snake, Food *foods);														/*产生食物的函数*/
void ProductFirst(Snakes *snake, int *boundary);												    /*产生蛇初始位置的函数*/
Snakes MoveSnake(Snakes *snake);																	/*蛇开始移动*/
void MoveUp(Snakes *snake);                                                                         /*向上移动*/
void MoveDown(Snakes *snake);                                                                       /*向下移动*/
void MoveLift(Snakes *snake);                                                                       /*向左移动*/
void MoveRight(Snakes *snake);                                                                      /*向右移动*/
void CollisionCheck(Snakes *snake, int int_difficulty);                                             /*碰撞检测*/
void EatTheFood(Food *foods, Snakes *snake);                                                        /*吃掉食物，增长*/
void QuitGame(int int_difficulty);                                                                  /*离开游戏*/
void CreateMapDate();                                                                               /*临时存储地图数据*/
/**********************************************************************************************************************/
int score  =  0 ;																 /*全局变量 记录分数  再次玩时结束后，清零*/
int int_Record_ClassicMode_easy;                                                 /*经典模式下，简单难度游戏个人最高记录*/
int int_Record_ClassicMode_secondary;                                            /*经典模式下，中等难度游戏个人最高记录*/
int int_Record_ClassicMode_difficulty;                                           /*经典模式下，困难难度游戏个人最高记录*/
int int_Record_AdvancedMode_bronze;                                              /*进阶模式下，青铜区，最高个人记录*/
int int_Record_AdvancedMode_hell;                                                /*进阶模式下，地狱区，最高个人记录*/
int int_Record_AdvancedMode_heaven;                                              /*进阶模式下，升天区，最高个人记录 */ /*文件中数字意义 按照此顺序*/
int int_Score;                                                                   /*记录每次游戏的分数*/
FILE *fp;                                                                        /*文件指针，打开和记录分数*/
Mapspots  BronzeMap[66];                                                         /*用于在游戏开始时 存储游戏地图 青铜区(初级难度)地图*/
Mapspots  hellMap[72];                                                           /*用于在游戏开始时 存储游戏地图 地狱区(中级难度)地图*/
Mapspots  HeavenMap[100];                                                        /*用于在游戏开始时 存储游戏地图 天堂区(高级难度)地图*/
/**********************************************************************************************************************/
int main(int argc, char *argv[])
{
	PlaySound(TEXT("beijing2.wav"), NULL, SND_FILENAME | SND_ASYNC | SND_LOOP);/*背景音乐*/
	SetConsoleTitleA("贪吃蛇");/*改变窗体的标题*/
	CreateMapDate();/*初始化地图*/
	InitialInterface();/*初始游戏界面  提供模式选择 记录查看 游戏退出接口*/
}
void InitialInterface()/*初始游戏界面  提供模式选择 记录查看 游戏退出接口*/
{
	system("cls");
	ReadPersonalRecord();
	char getsclear[30];
	char char_Mode_Shoose;
	Loop(7, "\n");
	Loop(4, "\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);	//设置颜色 
	Loop(60, "-");
	Loop(2, "\n");Loop(18, "   ");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	printf("☆ ☆贪 吃 蛇☆ ☆\n\n");
	Loop(5, " ");
	Loop(6, "\t");
	printf("       1.正常贪吃蛇\n");
	Loop(6, "\t");
	printf("       2.挺正常贪吃蛇\n");
	Loop(6, "\t");
	printf("       3.个人记录\n");
	Loop(6, "\t");
	printf("       4.帮助文档\n");
	Loop(6, "\t");
	printf("       5.退出游戏\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);/*设置文字颜色*/
	Loop(4, "\t");
	Loop(60, "-");Loop(1, "\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	Loop(4, "\t");
	printf("请输入游戏指令：");
	scanf("%c",&char_Mode_Shoose); /*选择游戏模式*/
	switch (char_Mode_Shoose)
	{
		case '1': 
			{
				int int_Difficulty = ClassicModeInterface();/*int_Difficulty 难度等级 约束值为 1或2或3*/
				ClassicModeGameStart(int_Difficulty);
                
			} break;
		case '2': 
			{
				AdvancedModeInterface();
		    }break;
		case '3': PersonalRecordView();break;
		case '4':HelpDocumentation();break;/*打开帮助文档*/
		case '5': exit(0);
		default: {
			system("cls");
			gets(getsclear);/*清空缓存*/
			InitialInterface();/*打开菜单界面*/
		}
		break;
	}
}
int  ClassicModeInterface()
{
	fflush(stdin);/*清空缓存*/
	system("cls");
	int int_Difficulty;/*选择当前模式下的游戏难度，传递给打印函数，设置刷新时间*/
	char getsclear[30];
	Loop(8, "\n");
	Loop(5, "\t");
	Loop(38, "*");
	Loop(1, "\n");
	Loop(5, "\t");
	printf("\t★ ☆ 经典模式 ☆ ★\n");
	Loop(1, "\n");
	Loop(6, "\t");
	printf("   1. ◇ 地狱模式\n");
	Loop(6, "\t");
	printf("   2. ◇ 人间模式\n");
	Loop(6, "\t");
	printf("   3. ◇ 天堂模式\n");
	Loop(6, "\t");
	printf("   4. ◇ 返回菜单\n");
	Loop(5, "\t");
	Loop(38, "*");
	Loop(1, "\n");
	Loop(5, "\t");
	printf("请输入游戏指令：");
	int int_error = scanf("%d", &int_Difficulty);
	if (int_Difficulty == 4) {
		gets(getsclear);
		fflush(stdin);
		InitialInterface();
	}
	if (int_error != 1 || int_Difficulty>3 || int_Difficulty<1)
	{
		fflush(stdin);
		system("cls");
		gets(getsclear);
		ClassicModeInterface();
	}
	return int_Difficulty;
}
void ClassicModeGameStart(int int_Difficulty )
{
	int int_Loop;
	Snakes snake[1056];
	Food foods;
	int int_SleepTime;/*定义刷屏时间*/
	if (int_Difficulty == 1) int_SleepTime = 50;
	else if (int_Difficulty == 2) int_SleepTime = 150;
	else if (int_Difficulty == 3) int_SleepTime = 300;
	else
	{
		printf(" error 01: 参数传递错误，应当传递 字符 1 或2或 3");
		system("pause");
		exit(1);
	}
	/*初始化蛇的结构体数组*/
	for (int_Loop = 0;int_Loop<1056;int_Loop++)
	{
		snake[int_Loop].column = -1;
		snake[int_Loop].Line = -1;
		snake[int_Loop].Statu = 0;
		snake[int_Loop].Direction = ' ';
	}
	/*初始化食物*/
	foods.Line = -1;
	foods.Column = -1;
	foods.status = 0;
	ProductFirst(snake,NULL);/*初始化蛇位置*/
	ProductFood(snake, &foods);/*初始化食物位置*/
	GameMapPrint(snake, &foods);/*打印地图和，蛇与食物的初次位置*/
	if(int_SleepTime==50) Sleep(2000);/*暂停两秒，以便用户找到自己的位置*/
	while (1)
	{
		Snakes snaketail=MoveSnake(snake);  /*移动函数*/
		ProductFood(snake, &foods);/*食物产生函数*/
		CollisionCheck(snake, int_Difficulty);/*碰撞检测函数*/
		EatTheFood(&foods, snake);/*吃食物判断函数*/
		GameInterfacePrint(snake, snaketail,&foods, int_SleepTime);/*打印游戏运行*/
	}

}
void ProductFood(Snakes *snake,Food *foods)/*产生经典模式下的文档*/
{
	First:	if (foods->status == 0)
	{
		int int_Food_Line, int_Food_Column, int_Loop;
		int_Food_Line = GetRandomValue(23);
		int_Food_Column = GetRandomValue(43);
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++)
		{
			if (int_Food_Line == snake[int_Loop].Line&&
				int_Food_Column == snake[int_Loop].column)
			{
				goto First;
			}
		}
		foods->Line = int_Food_Line;
		foods->Column = int_Food_Column;
		foods->status = 1;/*此时食物存在*/
	}
}
void GameInterfacePrint(Snakes *snake,Snakes snaketail,Food *foods,int int_SleepTime)
{
	/*获得现在蛇头的位置，打印为蛇头，获得现在蛇尾的位置打印为空方格 获得现在食物的位置和状态，如果未被吃掉则打印食物的位置*/
	int int_Loop, int_Countsnake=0;
	if (foods->status == 1)
	{
		GPS((*foods).Line, (*foods).Column);
		int int_food_style=GetRandomValue(4);
		if (int_food_style==1) printf("★");
		else if (int_food_style == 2) printf("▲");
		else if (int_food_style == 3) printf("☆");
		else if (int_food_style == 4) printf("◆");
	}
	for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*判断蛇身的长度*/
	{
		int_Countsnake++;
	}
	GPS(snake[0].Line, snake[0].column);
	printf("●");
	if (snake[0].Line!=snaketail.Line || snake[0].column!=snaketail.column)/*如果此时蛇头的位置 为之前蛇头的位置，则不打印为空格，防止蛇身消失*/
	{
		GPS(snaketail.Line, snaketail.column);
		printf("□");
	}
	GPS(25, 0);
	printf("得分：%d",score);
	Sleep(int_SleepTime);
}
void GameMapPrint(Snakes *snake, Food *foods)/*画出经典模式下的游戏地图*/
{
	system("cls");
	system("color 70");
	int  boundary[25][45], int_X, int_Y;
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if (int_X == 0 || int_X == 24 || int_Y == 0 || int_Y == 44)
			{
				boundary[int_X][int_Y] = 1;
			}
			else boundary[int_X][int_Y] = 2;
		}
	}
	for (int_X = 0;snake[int_X].Statu == 1;int_X++)
	{
		boundary[snake[int_X].Line][snake[int_X].column] = 3;
	}
	if ((*foods).status == 1)
	{
		int int_Style = GetRandomValue(4);
		switch (int_Style)
		{
		case 1:boundary[foods->Line][foods->Column] = 4;break;
		case 2:boundary[foods->Line][foods->Column] = 7;break;
		case 3:boundary[foods->Line][foods->Column] = 8;break;
		default:
			boundary[foods->Line][foods->Column] = 9;break;
			break;
		}
	}
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			GPS(int_X, int_Y);
			if (boundary[int_X][int_Y] == 1) printf("■");
			else if (boundary[int_X][int_Y] == 2) printf("□");
			else if (boundary[int_X][int_Y] == 4)   printf("★");
			else if (boundary[int_X][int_Y] == 3) printf("●");
			else if (boundary[int_X][int_Y] == 7) printf("♀");
			else if (boundary[int_X][int_Y] == 8) printf("♂");
			else if (boundary[int_X][int_Y] == 9) printf("◆");
		}
	}
}
void ProductFirst(Snakes *snake,int *boundary)
{
	if (boundary==NULL)
	{
		int int_defaultDirecion;
		int int_first_place_X = GetRandomValue(22);
		int int_first_place_Y = GetRandomValue(42);
		if (int_first_place_X >= 23 || int_first_place_X <= 0 ||
			int_first_place_Y >= 43 || int_first_place_Y <= 0)
		{
			ProductFirst(snake, boundary);
		}
		int_defaultDirecion = GetRandomValue(4);
		if (int_defaultDirecion == 1)
		{
			snake[0].Direction = 'W';
		}
		else if (int_defaultDirecion == 2)
		{
			snake[0].Direction = 'S';
		}
		else if (int_defaultDirecion == 3)
		{
			snake[0].Direction = 'A';
		}
		else if (int_defaultDirecion == 4)
		{
			snake[0].Direction = 'D';
		}
		snake[0].Line = int_first_place_X;
		snake[0].column = int_first_place_Y;
		snake[0].Statu = 1;
		snake[1].Line = int_first_place_X;
		snake[1].column = int_first_place_Y;
		snake[1].Statu = 1;
		snake[2].Line = int_first_place_X;
		snake[2].column = int_first_place_Y;
		snake[2].Statu = 1;

	}
}
Snakes MoveSnake(Snakes *snake)
{
	Snakes Snakestail;
	int int_Loop,int_Lenth_of_snake=0;
	for (int_Loop = 0;snake[int_Loop].Statu==1; int_Loop++)
	{
		int_Lenth_of_snake++;
	}
	Snakestail.Line = snake[int_Lenth_of_snake-1].Line;
	Snakestail.column = snake[int_Lenth_of_snake-1].column;
	if (GetAsyncKeyState('W')) {
		MoveUp(snake);
	}
	else if (GetAsyncKeyState('S')) {
		MoveDown(snake);
	}
	else if (GetAsyncKeyState('A')) {
		MoveLift(snake);
	}
	else if (GetAsyncKeyState('D')) {
		MoveRight(snake);
	}
	else
	{
		if (snake[0].Direction == 'W') {  /*1.默认为向上方向*/
			MoveUp(snake);
		}
		else if (snake[0].Direction == 'S') { /*2.默认为向下方向*/
			MoveDown(snake);
		}
		else if (snake[0].Direction == 'A') {/*3.默认方向向左方向*/
			MoveLift(snake);
		}
		else if (snake[0].Direction == 'D') {/*默认方向向右方向*/
			MoveRight(snake);
		}
	}
	return Snakestail;
}
/*向上移动 列不变 行加一 但是特殊情况 当下移动时不能再向上移动 否则此时为暂停*/
void MoveUp(Snakes *snake)
{
	if (snake[0].Direction != 'S')
	{
		int int_Loop, int_Count = 0;
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*判断蛇身的长度*/
		{
			int_Count++;
		}
		for (int_Loop = int_Count - 1;int_Loop >= 0;int_Loop--)
		{
			if (int_Loop != 0) {

				snake[int_Loop].column = snake[int_Loop - 1].column;
				snake[int_Loop].Line = snake[int_Loop - 1].Line;
				snake[int_Loop].Direction = snake[int_Loop - 1].Direction;

			}
			else {
				snake[0].Line = snake[0].Line - 1;
				snake[0].column = snake[0].column;
			}
		}
		snake[0].Direction = 'W';
	}
	else
	{
		MoveDown(snake);
	}
	return;
}
/*向下移动 行变列不变 但是特殊情况 当上移动时不能再向下移动 否则此时为暂停*/
void MoveDown(Snakes *snake)
{
	if (snake[0].Direction != 'W')
	{
		int int_Loop, int_Count = 0;
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*判断蛇身的长度*/
		{
			int_Count++;
		}
		for (int_Loop = int_Count - 1;int_Loop >= 0;int_Loop--)
		{
			if (int_Loop != 0) {
				snake[int_Loop].column = snake[int_Loop - 1].column;
				snake[int_Loop].Line = snake[int_Loop - 1].Line;
				snake[int_Loop].Direction = snake[int_Loop - 1].Direction;
			}
			else {
				snake[0].Line = snake[0].Line + 1;
				snake[0].column = snake[0].column;
			}
		}
		snake[0].Direction = 'S';
	}
	else
	{
		MoveUp(snake);
	}
	return;
}
/*向左 移动 行不变，列-1 特殊 不可向想法方向移动*/
void MoveLift(Snakes *snake)
{
	if (snake[0].Direction != 'D')
	{
		int int_Loop, int_Count = 0;
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*判断蛇身的长度*/
		{
			int_Count++;
		}
		for (int_Loop = int_Count - 1;int_Loop >= 0;int_Loop--)
		{
			if (int_Loop != 0) {
				snake[int_Loop].column = snake[int_Loop - 1].column;
				snake[int_Loop].Line = snake[int_Loop - 1].Line;
				snake[int_Loop].Direction = snake[int_Loop - 1].Direction;
			}
			else {
				snake[0].column = snake[0].column - 1;
				snake[0].Line = snake[0].Line;
			}
		}
		snake[0].Direction = 'A';
	}
	else
	{
		MoveRight(snake);
	}
	return;
}
void MoveRight(Snakes *snake)
{
	if (snake[0].Direction != 'A')
	{
		int int_Loop, int_Count = 0;
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*判断蛇身的长度*/
		{
			int_Count++;
		}
		for (int_Loop = int_Count - 1;int_Loop >= 0;int_Loop--)
		{
			if (int_Loop != 0) {
				snake[int_Loop].column = snake[int_Loop - 1].column;
				snake[int_Loop].Line = snake[int_Loop - 1].Line;
				snake[int_Loop].Direction = snake[int_Loop - 1].Direction;
			}
			else {
				snake[0].column = snake[0].column + 1;
				snake[0].Line = snake[0].Line;
			}
		}
		snake[0].Direction = 'D';
	}
	else
	{
		MoveLift(snake);
	}
	return;
}
void CollisionCheck(Snakes *snake,int int_difficulty)
{
	int int_Loop, int_Count = 0, int_Countsnake = 0;
	/*检测碰墙*/
	/*当行和为0或24时 或 列为0或44时 撞墙*/
	if (snake[0].column == 0 || snake[0].column == 44 ||
		snake[0].Line == 0 || snake[0].Line == 24)
	{
		QuitGame(int_difficulty);
	}
	/*碰撞自己检测*/
	for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*判断蛇身的长度*/
	{
		int_Countsnake++;
	}
	if (int_Countsnake>3)
	{
		for (int_Loop = 1;snake[int_Loop].Statu == 1;int_Loop++)
		{
			if (snake[0].Line == snake[int_Loop].Line&&
				snake[0].column == snake[int_Loop].column)
			{
				QuitGame(int_difficulty);
			}
		}
	}
}
void EatTheFood(Food *foods, Snakes *snake)
{
	int int_Count = 0, int_Loop = 0;
	//system("pause");
	if ((*foods).Line == snake[0].Line && (*foods).Column == snake[0].column)
	{
		score++;
		foods->status = 0;
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*判断蛇身的长度 得到现在的蛇尾的位置 以便得到蛇尾的方向*/
		{
			int_Count++;
		}
		switch (snake[int_Count - 1].Direction)
		{
		case 'W':
		{
			snake[int_Count].Statu = 1;/*开启下一个节点*/
			snake[int_Count].Line = snake[int_Count - 1].Line + 1;
			snake[int_Count].column = snake[int_Count - 1].column;
			snake[int_Count].Direction = 'W';
		}
		break;
		case 'S':
		{
			snake[int_Count].Statu = 1;/*开启下一个节点*/
			snake[int_Count].Line = snake[int_Count - 1].Line - 1;
			snake[int_Count].column = snake[int_Count - 1].column;
			snake[int_Count].Direction = 'S';
		}
		break;
		case 'A':
		{
			snake[int_Count].Statu = 1;/*开启下一个节点*/
			snake[int_Count].Line = snake[int_Count - 1].Line;
			snake[int_Count].column = snake[int_Count - 1].column + 1;
			snake[int_Count].Direction = 'A';
		}
		break;
		case 'D':
		{
			snake[int_Count].Statu = 1;/*开启下一个节点*/
			snake[int_Count].Line = snake[int_Count - 1].Line;
			snake[int_Count].column = snake[int_Count - 1].column - 1;
			snake[int_Count].Direction = 'D';
		}
		}
	}
}
void QuitGame(int int_difficulty)
{
	system("color 04");
	int int_Break_The_Record=0;
	system("cls");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);
	Loop(8, "\n");
	Loop(5, "\t");
	Loop(40,"*");
	printf("\n");
	Loop(5, "\t");
	printf("*                                      *\n");
	Loop(5, "\t");
	if(score<10)                      printf("*            当前成绩：%d               *\n",score);
	else if (score>=10 && score<100)  printf("*            当前成绩：%d              *\n", score);
	else if (score>100 && score<1000) printf("*            当前成绩：%d             *\n", score);
	else if (score>=1000)             printf("*            当前成绩：%d            *\n", score);
	/*记录是否修改的判断*/
	if (int_difficulty == 3)
	{
		if (score > int_Record_ClassicMode_easy)
		{
			int_Record_ClassicMode_easy = score;
			int_Break_The_Record = 1;
		}
	}
	else if (int_difficulty == 2)
	{
		if (score > int_Record_ClassicMode_secondary) 
		{
			int_Record_ClassicMode_secondary = score;
			int_Break_The_Record = 1;
		}
	}
	else if (int_difficulty == 1)
	{
		if (score > int_Record_ClassicMode_difficulty) 
		{ 
			int_Record_ClassicMode_difficulty = score;
			int_Break_The_Record = 1;
		}
	}
	else if (int_difficulty == 4)
	{
		if (score > int_Record_AdvancedMode_bronze)
		{
			int_Record_AdvancedMode_bronze = score;
			int_Break_The_Record = 1;
		}
	}
	else if (int_difficulty == 5)
	{
		if (score > int_Record_AdvancedMode_hell)
		{
			int_Record_AdvancedMode_hell = score;
			int_Break_The_Record = 1;
		}
	}
	else if (int_difficulty == 6)
	{
		if (score > int_Record_AdvancedMode_heaven)
		{
			int_Record_AdvancedMode_heaven = score;
			int_Break_The_Record = 1;
		}
	}
	if (int_Break_The_Record == 1)
	{
		Loop(5, "\t");
		printf("*            恭喜你！新记录！          *\n");
	}
	Loop(5, "\t");
	printf("*            即将返回主菜单！          *\n");
	Loop(5, "\t");
	Loop(40, "*");
	score = 0;
	printf("\n");
	Loop(5, "\t");
	WritePersonalRecord();
	system("pause");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);/*恢复颜色*/
	InitialInterface();
}
void AdvancedModeInterface()
{
	system("cls");
	char getsclear[30];
	char char_command_1='4';
	Loop(8, "\n");
	Loop(4, "\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);
	Loop(25, "★");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	printf("\n\n");
	Loop(6, "\t");
	printf("☆ ☆进阶模式☆ ☆\n\n");
	Loop(6, "\t");
	printf("1.◇ 高级玩家\n");
	Loop(6, "\t");
	printf("2.◇ 中级玩家\n");
	Loop(6, "\t");
	printf("3.◇ 低级玩家\n");
	Loop(6, "\t");
	printf("4.◇ 返回菜单\n\n");
	Loop(4, "\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);
	Loop(25, "★");
	printf("\n");
	Loop(4, "\t");
	printf("请输入游戏等级:");
	scanf("%c", &char_command_1);
	if (char_command_1 == '1') 
	{
		int int_Loop;
		Snakes snake[928];
		Food foods;
		for (int_Loop = 0;int_Loop<928;int_Loop++)
		{
			snake[int_Loop].column = -1;
			snake[int_Loop].Line = -1;
			snake[int_Loop].Statu = 0;
			snake[int_Loop].Direction = ' ';
		}
		/*初始化食物*/
		foods.Line = -1;
		foods.Column = -1;
		foods.status = 0;
		system("color 70");
		AdvancedModeProductFirst(snake, 6);					     /*产生蛇的初始位置*/
		AdvancedModeProductFood(snake, &foods, 6);			     /*产生食物的初始位置*/
		AdvancedModeHeavenGameMapPrint(snake, &foods);			 /*产生游戏地图*/
		Sleep(2000);										     /*暂停两秒*/
		while (1)
		{
			Snakes snaketail = MoveSnake(snake);                 /*移动函数*/
			AdvancedModeProductFood(snake, &foods, 6);           /*食物产生*/
			AdvancedCollisionCheck(snake, 6);                    /*碰撞检测*/
			EatTheFood(&foods, snake);                           /*吃食物*/
			GameInterfacePrint(snake, snaketail, &foods, 150);   /*游戏界面打印*/
		}
	}
	else if (char_command_1 == '2')
	{
		int int_Loop;
		Snakes snake[928];
		Food foods;
		for (int_Loop = 0;int_Loop<928;int_Loop++)
		{
			snake[int_Loop].column = -1;
			snake[int_Loop].Line = -1;
			snake[int_Loop].Statu = 0;
			snake[int_Loop].Direction = ' ';
		}
		/*初始化食物*/
		foods.Line = -1;
		foods.Column = -1;
		foods.status = 0;
		system("color 70");
		AdvancedModeProductFirst(snake, 5);
		AdvancedModeProductFood(snake, &foods, 5);
		AdvancedModeHellGameMapPrint(snake, &foods);
		Sleep(2000);
		while (1)
		{
			Snakes snaketail = MoveSnake(snake);
			AdvancedModeProductFood(snake, &foods, 5);
			AdvancedCollisionCheck(snake, 5);
			EatTheFood(&foods, snake);
			GameInterfacePrint(snake, snaketail, &foods, 150);
		}
	}
	else if (char_command_1 == '3') 
	{
		int int_Loop;
		Snakes snake[928];
		Food foods;
		for (int_Loop = 0;int_Loop<928;int_Loop++)
		{
			snake[int_Loop].column = -1;
			snake[int_Loop].Line = -1;
			snake[int_Loop].Statu = 0;
			snake[int_Loop].Direction = ' ';
		}
		/*初始化食物*/
		foods.Line = -1;
		foods.Column = -1;
		foods.status = 0;
		system("color 87");
		AdvancedModeProductFirst(snake,4);
		AdvancedModeProductFood(snake, &foods,4);
		AdvancedModeBronzeGameMapPrint(snake, &foods);
		Sleep(2000);
		while (1)
		{
			Snakes snaketail = MoveSnake(snake);
			AdvancedModeProductFood(snake, &foods,4);
			AdvancedCollisionCheck(snake, 4);
			EatTheFood(&foods, snake);
			GameInterfacePrint(snake, snaketail, &foods,200);
		}
	}
	else if (char_command_1 == '4')
	{
		gets(getsclear);
		fflush(stdin);
		InitialInterface();
	}
	else
	{
		AdvancedModeInterface();
	}

}
void AdvancedModeBronzeGameMapPrint(Snakes *snake, Food *foods)
{
	system("cls");
	fflush(stdin);
	int  boundary[25][45], int_X, int_Y,int_Loop=0;
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if (int_X == 0 || int_X == 24 || int_Y == 0 || int_Y == 44)
			{
				boundary[int_X][int_Y] = 1;
			}
			else boundary[int_X][int_Y] = 2;
		}
	}
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if (((int_X >=4 && int_X<20)) && int_Y == 22)
			{
				boundary[int_X][int_Y] = 1;
				int_Loop++;
			}
			else if ((int_X == 7) && (int_Y >= 10 && int_Y <= 34))
			{
				boundary[int_X][int_Y] = 1;
				int_Loop++;
			}
			else if ((int_X == 16) && (int_Y >= 10 && int_Y <= 34))
			{
				boundary[int_X][int_Y] = 1;
				int_Loop++;
			}
		}
	}
	/*打印蛇的位置和食物的位置*/
	for (int_X = 0;snake[int_X].Statu == 1;int_X++)
	{
		boundary[snake[int_X].Line][snake[int_X].column] = 3;
	}
	if ((*foods).status == 1)
	{
		int int_Style = GetRandomValue(4);
		switch (int_Style)
		{
		case 1:boundary[foods->Line][foods->Column] = 4;break;
		case 2:boundary[foods->Line][foods->Column] = 7;break;
		case 3:boundary[foods->Line][foods->Column] = 8;break;
		default:
			boundary[foods->Line][foods->Column] = 9;break;
			break;
		}
	}
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			GPS(int_X, int_Y);
			if (boundary[int_X][int_Y] == 1) printf("■");
			else if (boundary[int_X][int_Y] == 2) printf("□");
			else if (boundary[int_X][int_Y] == 4)   printf("★");
			else if (boundary[int_X][int_Y] == 3) printf("●");
			else if (boundary[int_X][int_Y] == 7) printf("♀");
			else if (boundary[int_X][int_Y] == 8) printf("♂");
			else if (boundary[int_X][int_Y] == 9) printf("◆");
		}
	}
}
void AdvancedModeProductFood(Snakes *snake, Food *foods,int int_Mode)
{
  int int_Loop_Times=0;
  First:	if (foods->status == 0)
    {
		int int_Loop;
		int int_Food_Line, int_Food_Column;
		int_Food_Line = GetRandomValue(23);
		int_Food_Column = GetRandomValue(43);
		if (int_Mode==4)
		{
			for (int_Loop = 0; int_Loop < 64; int_Loop++)
			{
				if (int_Food_Line == BronzeMap[int_Loop].line && int_Food_Column == BronzeMap[int_Loop].Column)
				{
					goto First;
					int_Loop_Times++;
					if (int_Loop_Times == 5)
					{
						return;
					}
				}
			}
		}
		else if(int_Mode == 5)
		{
			for (int_Loop = 0; int_Loop < 72; int_Loop++)
			{
				if (int_Food_Line == hellMap[int_Loop].line && int_Food_Column == hellMap[int_Loop].Column)
				{
					goto First;
					int_Loop_Times++;
					if (int_Loop_Times == 5)
					{
						return;
					}
				}
			}
		}
		else if (int_Mode == 6)
		{
			for (int_Loop = 0; int_Loop < 98; int_Loop++)
			{
				if (int_Food_Line == HeavenMap[int_Loop].line && int_Food_Column == HeavenMap[int_Loop].Column)
				{
					goto First;
					int_Loop_Times++;
					if (int_Loop_Times == 5)
					{
						return;
					}
				}
			}
		}

	for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++)
	{
		if (int_Food_Line == snake[int_Loop].Line&&
			int_Food_Column == snake[int_Loop].column)
		{
			goto First;
			int_Loop_Times++;
			if (int_Loop_Times == 5)
			{
				return;
			}
		}
	}
	foods->Line = int_Food_Line;
	foods->Column = int_Food_Column;
	foods->status = 1;/*此时食物存在*/
  }
}
void AdvancedModeProductFirst(Snakes *snake,int int_Mode)
{
	    int int_defaultDirecion, int_Loop;
	First:	if (1);
		int int_first_place_X = GetRandomValue(22);
		int int_first_place_Y = GetRandomValue(42);
		if (int_first_place_X >= 23 || int_first_place_X <= 0 ||
			int_first_place_Y >= 43 || int_first_place_Y <= 0)
		{
			goto  First;
		}
		if (int_Mode==4)
		{
			for (int_Loop = 0; int_Loop < 64; int_Loop++)
			{
				if (int_first_place_X == BronzeMap[int_Loop].line && int_first_place_Y == BronzeMap[int_Loop].Column)
				{
					goto  First;
				}
			}
		}
		else if (int_Mode==5)
		{
			for (int_Loop = 0; int_Loop < 72; int_Loop++)
			{
				if (int_first_place_X == hellMap[int_Loop].line && int_first_place_Y == hellMap[int_Loop].Column)
				{
					goto  First;
				}
			}
		}
		else if (int_Mode == 6)
		{
			for (int_Loop = 0; int_Loop < 72; int_Loop++)
			{
				if (int_first_place_X == HeavenMap[int_Loop].line && int_first_place_Y == HeavenMap[int_Loop].Column)
				{
					goto  First;
				}
			}
		}
		int_defaultDirecion = GetRandomValue(4);
		if (int_defaultDirecion == 1)
		{
			snake[0].Direction = 'W';
		}
		else if (int_defaultDirecion == 2)
		{
			snake[0].Direction = 'S';
		}
		else if (int_defaultDirecion == 3)
		{
			snake[0].Direction = 'A';
		}
		else if (int_defaultDirecion == 4)
		{
			snake[0].Direction = 'D';
		}
		snake[0].Line = int_first_place_X;
		snake[0].column = int_first_place_Y;
		snake[0].Statu = 1;
		snake[1].Line = int_first_place_X;
		snake[1].column = int_first_place_Y;
		snake[1].Statu = 1;
		snake[2].Line = int_first_place_X;
		snake[2].column = int_first_place_Y;
		snake[2].Statu = 1;	
}
void AdvancedCollisionCheck(Snakes *snake, int int_difficulty)
{
		int int_Loop, int_Count = 0, int_Countsnake = 0;
		/*检测碰墙*/
		/*当行和为0或24时 或 列为0或44时 撞墙*/
		if (snake[0].column == 0 || snake[0].column == 44 ||
			snake[0].Line == 0 || snake[0].Line == 24)
		{
			QuitGame(int_difficulty);
		}
		if (int_difficulty==4)
		{
			for (int_Loop = 0; int_Loop < 64; int_Loop++)
			{
				if (BronzeMap[int_Loop].line == snake[0].Line && BronzeMap[int_Loop].Column == snake[0].column)
				{
					QuitGame(int_difficulty);
				}
			}
		}
		else if(int_difficulty==5)
		{
			for (int_Loop = 0; int_Loop < 72; int_Loop++)
			{
				if (hellMap[int_Loop].line == snake[0].Line && hellMap[int_Loop].Column == snake[0].column)
				{
					QuitGame(int_difficulty);
				}
			}
		}
		else if (int_difficulty == 6)
		{
			for (int_Loop = 0; int_Loop < 98; int_Loop++)
			{
				if (HeavenMap[int_Loop].line == snake[0].Line && HeavenMap[int_Loop].Column == snake[0].column)
				{
					QuitGame(int_difficulty);
				}
			}
		}
		/*碰撞自己检测*/
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*判断蛇身的长度*/
		{
			int_Countsnake++;
		}
		if (int_Countsnake>3)
		{
			for (int_Loop = 1;snake[int_Loop].Statu == 1;int_Loop++)
			{
				if (snake[0].Line == snake[int_Loop].Line&&
					snake[0].column == snake[int_Loop].column)
				{
					QuitGame(int_difficulty);
				}
			}
		}
}
void AdvancedModeHellGameMapPrint(Snakes *snake, Food *foods)
{
	system("cls");
	fflush(stdin);
	int  boundary[25][45], int_X, int_Y;
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if (int_X == 0 || int_X == 24 || int_Y == 0 || int_Y == 44)
			{
				boundary[int_X][int_Y] = 1;
			}
			else boundary[int_X][int_Y] = 2;
		}
	}
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if ((int_X>=3&&int_X<=9)&&(int_Y==11||int_Y==32))
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X >= 14 && int_X <= 21) && (int_Y == 11 || int_Y == 32))
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_Y>=1&&int_Y<=11)&& (int_X==9||int_X==14))
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_Y >= 32 && int_Y <= 43) && (int_X == 9 || int_X == 14))
			{
				boundary[int_X][int_Y] = 1;
			}
		}
	}
	for (int_X = 0;snake[int_X].Statu == 1;int_X++)
	{
		boundary[snake[int_X].Line][snake[int_X].column] = 3;
	}
	if ((*foods).status == 1)
	{
		int int_Style = GetRandomValue(4);
		switch (int_Style)
		{
		case 1:boundary[foods->Line][foods->Column] = 4;break;
		case 2:boundary[foods->Line][foods->Column] = 7;break;
		case 3:boundary[foods->Line][foods->Column] = 8;break;
		default:
			boundary[foods->Line][foods->Column] = 9;break;
			break;
		}
	}
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			GPS(int_X, int_Y);
			if (boundary[int_X][int_Y] == 1) printf("■");
			else if (boundary[int_X][int_Y] == 2) printf("□");
			else if (boundary[int_X][int_Y] == 4)   printf("★");
			else if (boundary[int_X][int_Y] == 3) printf("●");
			else if (boundary[int_X][int_Y] == 7) printf("♀");
			else if (boundary[int_X][int_Y] == 8) printf("♂");
			else if (boundary[int_X][int_Y] == 9) printf("◆");
		}
	}
}
void AdvancedModeHeavenGameMapPrint(Snakes *snake, Food *foods)
{
	system("cls");
	fflush(stdin);
	int  boundary[25][45], int_X, int_Y;
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if (int_X == 0 || int_X == 24 || int_Y == 0 || int_Y == 44)
			{
				boundary[int_X][int_Y] = 1;
			}
			else boundary[int_X][int_Y] = 2;
		}
	}
	for (int_X = 0;int_X<25;int_X++)/*打印游戏地图 所需要的坐标 标记*/
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if ((int_X>=2&&int_X<=18)&&int_Y==22)
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X >= 1 && int_X <= 4) && int_Y == 29)
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X >= 16 && int_X <= 23) && int_Y == 29)
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X >= 3 && int_X <= 18) && int_Y == 35)
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X == 4||int_X==18) && (int_Y >= 31 && int_Y <= 33))
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X >= 2 && int_X <= 10) && int_Y == 2)
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X == 2) && (int_Y >= 2 && int_Y <= 10))
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X == 10) && (int_Y >= 2 && int_Y <= 7))
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X >= 2 && int_X <= 7) && int_Y == 10)
			{
				boundary[int_X][int_Y] = 1;
			}
			if (int_X ==10 && int_Y == 10)
			{
				boundary[int_X][int_Y] = 1;
			}
			if (int_X == 17 && (int_Y >= 1&&int_Y<=15))
			{
				boundary[int_X][int_Y] = 1;
			}
			if ((int_X >= 18 && int_X<= 21)&& int_Y == 15)
			{
				boundary[int_X][int_Y] = 1;
			}
		}
	}
	for (int_X = 0;snake[int_X].Statu == 1;int_X++)
	{
		boundary[snake[int_X].Line][snake[int_X].column] = 3;
	}
	if ((*foods).status == 1)/*如果食物状态事1 则食物没有被吃掉 则打印出食物*/
	{
		int int_Style = GetRandomValue(4);
		switch (int_Style)
		{
		case 1:boundary[foods->Line][foods->Column] = 4;break;
		case 2:boundary[foods->Line][foods->Column] = 7;break;
		case 3:boundary[foods->Line][foods->Column] = 8;break;
		default:
			boundary[foods->Line][foods->Column] = 9;break;
			break;
		}
	}
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			GPS(int_X, int_Y);
			if (boundary[int_X][int_Y] == 1) printf("■");
			else if (boundary[int_X][int_Y] == 2) printf("□");
			else if (boundary[int_X][int_Y] == 4)   printf("★");
			else if (boundary[int_X][int_Y] == 3) printf("●");
			else if (boundary[int_X][int_Y] == 7) printf("♀");
			else if (boundary[int_X][int_Y] == 8) printf("♂");
			else if (boundary[int_X][int_Y] == 9) printf("◆");
		}
	}
}
void PersonalRecordView()
{
	system("cls");
	Loop(8, "\n");
	Loop(5, "\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);
	Loop(35, "-");
	printf("\n\t\t\t\t\t\t★ ☆ 最佳战绩 ☆ ★\n\t\t\t\t\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	printf("   经典模式： 1.地狱 :%d",int_Record_ClassicMode_difficulty);
	printf("\n\t\t\t\t\t\t      2.人间：%d", int_Record_ClassicMode_secondary);
	printf("\n\t\t\t\t\t\t      3.天堂：%d", int_Record_ClassicMode_easy);
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);
	printf("\n\t\t\t\t\t   进阶模式： 1.高级 :%d", int_Record_AdvancedMode_heaven);
	printf("\n\t\t\t\t\t\t      2.中等 :%d", int_Record_AdvancedMode_hell);
	printf("\n\t\t\t\t\t\t      3.初级 :%d\n", int_Record_AdvancedMode_bronze);
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);
	Loop(5, "\t");	Loop(35, "-");
	printf("\n");
	Loop(5, "\t");
	system("pause");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
	InitialInterface();/*返回界面*/


}
void WritePersonalRecord()
{
	fp = fopen("Record.txt", "w+");
	if (fp == NULL) {
		printf("Can not Open this file");
		system("pause");
		exit(0);
	}
	fprintf(fp, "%d,%d,%d,%d,%d,%d", int_Record_ClassicMode_easy, int_Record_ClassicMode_secondary,
		int_Record_ClassicMode_difficulty, int_Record_AdvancedMode_bronze, int_Record_AdvancedMode_hell, int_Record_AdvancedMode_heaven);
	fclose(fp);
}
void ReadPersonalRecord()
{
	/*从文件中读出游戏记录*/
	fp = fopen("Record.txt", "r+");
	if (fp == NULL) {
		printf("Can not Open this file");
		system("pause");
		exit(0);
	}
	//fprintf(fp, "%d,%d,%d,%d,%d,%d", 0,0,0,0,0,0);	
	fscanf(fp, "%d,%d,%d,%d,%d,%d", &int_Record_ClassicMode_easy, &int_Record_ClassicMode_secondary,
		&int_Record_ClassicMode_difficulty, &int_Record_AdvancedMode_bronze, &int_Record_AdvancedMode_hell, &int_Record_AdvancedMode_heaven);
	fclose(fp);
}
void CreateMapDate()
{
	int int_X=0, int_Y=0,int_Loop=0;
	for (int_X = 0;int_X < 66;int_X++)
	{
		BronzeMap[int_X].line = -1;
		BronzeMap[int_X].Column = -1;
	}
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if (((int_X >= 4 && int_X<20)) && int_Y == 22)
			{
				BronzeMap[int_Loop].line = int_X;
				BronzeMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X == 7) && (int_Y >= 10 && int_Y <= 34))
			{
				BronzeMap[int_Loop].line = int_X;
				BronzeMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X == 16) && (int_Y >= 10 && int_Y <= 34))
			{
				BronzeMap[int_Loop].line = int_X;
				BronzeMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
		}
	}
	int_Loop = 0;
	for (int_X = 0;int_X < 25;int_X++)
	{
		for (int_Y = 0;int_Y < 45;int_Y++)
		{
			if ((int_X >= 3 && int_X <= 9) && (int_Y == 11 || int_Y == 32))
			{
				hellMap[int_Loop].line = int_X;
				hellMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X >= 14 && int_X <= 21) && (int_Y == 11 || int_Y == 32))
			{
				hellMap[int_Loop].line = int_X;
				hellMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_Y >= 1 && int_Y <= 11) && (int_X == 9 || int_X == 14))
			{
				hellMap[int_Loop].line = int_X;
				hellMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_Y >= 32 && int_Y <= 43) && (int_X == 9 || int_X == 14))
			{
				hellMap[int_Loop].line = int_X;
				hellMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
		}
	}
	int_Loop = 0;
	for (int_X = 0;int_X<25;int_X++)
	{
		for (int_Y = 0;int_Y<45;int_Y++)
		{
			if ((int_X >= 2 && int_X <= 18) && int_Y == 22)
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X >= 1 && int_X <= 4) && int_Y == 29)
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X >= 16 && int_X <= 23) && int_Y == 29)
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X >= 3 && int_X <= 18) && int_Y == 35)
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X == 4 || int_X == 18) && (int_Y >= 31 && int_Y <= 33))
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X >= 2 && int_X <= 10) && int_Y == 2)
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X == 2) && (int_Y >= 2 && int_Y <= 10))
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X == 10) && (int_Y >= 2 && int_Y <= 7))
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if ((int_X >= 2 && int_X <= 7) && int_Y == 10)
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if (int_X == 10 && int_Y == 10)
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
			else if (int_X == 17 && (int_Y >= 1 && int_Y <= 15)){
				HeavenMap[int_Loop].line = int_X;
			    HeavenMap[int_Loop].Column = int_Y;
			   int_Loop++;
			}
			else if ((int_X >= 18 && int_X <= 21) && int_Y == 15)
			{
				HeavenMap[int_Loop].line = int_X;
				HeavenMap[int_Loop].Column = int_Y;
				int_Loop++;
			}
		}
	}
}
void HelpDocumentation()
{
	system("cls");
	Loop(5, "\n");
	Loop(5, "\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);
	Loop(3, "★★★★★★★");
	printf("\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	Loop(5, "\t");
	printf("\t  ☆ ☆ ☆ 说明书 ☆ ☆ ☆\n\n");
	Loop(5, "\t");
	printf("\t\t 控制方法\t\t\n");
	Loop(5, "\t");
	printf("\t 上:W  下:S  左:A  右:D\t\n");
	Loop(5, "\t");
	printf("\t\t游戏结束判断\t\t\n");
	Loop(5, "\t");
	printf("\t蛇碰到边界或者自己则游戏结束\t\n");
	Loop(5, "\t");
	printf("\t当分数达到一定时游戏结束\t\n\n");
	Loop(5, "\t");
	printf("    ◇     返回黑屏时请按回车!      ◇\n");
	Loop(5, "\t");
	printf("    ◇ 游戏暂停：鼠标点击游戏界面！ ◇\n");
	Loop(5, "\t");
	printf("    ◇ 高难度游戏开始时会暂停两秒！ ◇\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);/*设置背景色*/
	Loop(5, "\t");
	Loop(3, "★★★★★★★");
	printf("\n");Loop(5, "\t");
	system("pause");
	InitialInterface();
}
int  GetRandomValue(int int_Max)/*产生随机数*/
{
	srand((unsigned int)time(NULL));
	return rand() % int_Max + 1;
}
void Loop(int int_loop, char Str[20])
{
	int loop;
	for (loop = 0;loop<int_loop;loop++) printf("%s", Str);
}
void GPS(int x, int y)//定位光标位置
{
	COORD pos;
	HANDLE hOutput;
	pos.X = y * 2+10;
	pos.Y = x+3;
	hOutput = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCursorPosition(hOutput, pos);
}