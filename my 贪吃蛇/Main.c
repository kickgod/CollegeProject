#include<stdio.h>
#include<stdlib.h>
#include<Windows.h>
#include<MMSystem.h>
#include<time.h>
#pragma comment(lib,"Winmm.lib")
/***********************************************     ���ݶ���   ****************************************************/
typedef struct Snakenode {
	int column;                                                                /*�洢�߽ڵ�������*/
	int Line;                                                                  /*�洢�߽ڵ�������*/
	int Statu;                                                                 /*��ʾ�˽��Ƿ���� Ϊ1���ӡ��һ�ڵ����� ���� ����ӡ*/
	char Direction;                                                            /*��ʾ�ߵķ��򣬱��ڵõ��ߵ����һ�ڵķ���*/
} Snakes;                                                                      /*�ߵĽڵ�*/
typedef struct food
{
	int Line;                                                                   /*�洢ʳ��������*/
	int Column;                                                                 /*�洢ʳ��������*/
	int status;                                                                 /*��ʾʳ���״̬����������ʳ��ʱ���ж���״̬*/
} Food;																	        /*��Ϊ0������ʳ�������*/
			                                                                    /* ���������� ÿ���߳Ե�ʳ�������ʳ��״̬Ϊ0*/
typedef struct Mapspot
{
	int line;
	int Column;
} Mapspots;
/******************************                    ������ƺ���                  ********************************/
void InitialInterface();                                                         /*��ʼ��Ϸ����          */
int ClassicModeInterface();                                                      /*����ģʽ���Ѷ�ѡ�����*/
void AdvancedModeInterface();                                                    /*����ģʽ���Ѷ�ѡ�����*/
void PersonalRecordView();                                                       /*���˼�¼�鿴*/
void ReadPersonalRecord();                                                       /*���ļ��ж������˼�¼*/
void WritePersonalRecord();                                                      /*���µĸ��˼�¼д���ļ�*/
void HelpDocumentation();                                                        /*��Ϸ����˵��*/
/****************************************************************************************************************/

/*****************************                     �������ܺ���                  ********************************/
void Loop(int int_loop, char Str[20]);                                           /*����ĳЩ�ַ���ѭ�����*/
void GPS(int x, int y);                                                          /*���ڶ�λ���λ��*/
int GetRandomValue(int int_Max);                                                 /*���������*/
/****************************************************************************************************************/
/*                                      �����������������������������                                    */
/*****************************                     ��Ϸ���к���                  ********************************/
void ClassicModeGameStart(int int_Difficulty);                                                      /*���о���ģʽ�µ���Ϸ*/
void GameMapPrint(Snakes *snake,Food *foods);                                                       /*��ӡ��ͼ����ͼ���ݣ���Ϊ������ģʽ�򷵻ص�ͼ����*/
void AdvancedModeBronzeGameMapPrint(Snakes *snake, Food *foods);                                    /*��ӡ ����ģʽ�µĳ��������Ϸ��ͼ*/
void AdvancedModeProductFood(Snakes *snake, Food *foods, int int_Mode);								/*���� ����ģʽ�µ�  ʳ�����λ�ú���*/
void AdvancedModeProductFirst(Snakes *snake,int int_Mode);                                          /*���� ����ģʽ�µ�  �߳���λ�ú���*/
void AdvancedCollisionCheck(Snakes *snake, int int_difficulty);                                     /*����ģʽ�µ� ��ײ���*/
void AdvancedModeHellGameMapPrint(Snakes *snake, Food *foods);                                      /*��ӡ����ģʽ�µ��м������Ϸ��ͼ*/
void AdvancedModeHeavenGameMapPrint(Snakes *snake, Food *foods);                                    /*��ӡ����ģʽ�µĸ߼������Ϸ��ͼ*/
void GameInterfacePrint(Snakes *snake, Snakes snaketail, Food *foods, int int_SleepTime);          /*��ӡ�ߵ��ƶ�*/
void ProductFood(Snakes *snake, Food *foods);														/*����ʳ��ĺ���*/
void ProductFirst(Snakes *snake, int *boundary);												    /*�����߳�ʼλ�õĺ���*/
Snakes MoveSnake(Snakes *snake);																	/*�߿�ʼ�ƶ�*/
void MoveUp(Snakes *snake);                                                                         /*�����ƶ�*/
void MoveDown(Snakes *snake);                                                                       /*�����ƶ�*/
void MoveLift(Snakes *snake);                                                                       /*�����ƶ�*/
void MoveRight(Snakes *snake);                                                                      /*�����ƶ�*/
void CollisionCheck(Snakes *snake, int int_difficulty);                                             /*��ײ���*/
void EatTheFood(Food *foods, Snakes *snake);                                                        /*�Ե�ʳ�����*/
void QuitGame(int int_difficulty);                                                                  /*�뿪��Ϸ*/
void CreateMapDate();                                                                               /*��ʱ�洢��ͼ����*/
/**********************************************************************************************************************/
int score  =  0 ;																 /*ȫ�ֱ��� ��¼����  �ٴ���ʱ����������*/
int int_Record_ClassicMode_easy;                                                 /*����ģʽ�£����Ѷ���Ϸ������߼�¼*/
int int_Record_ClassicMode_secondary;                                            /*����ģʽ�£��е��Ѷ���Ϸ������߼�¼*/
int int_Record_ClassicMode_difficulty;                                           /*����ģʽ�£������Ѷ���Ϸ������߼�¼*/
int int_Record_AdvancedMode_bronze;                                              /*����ģʽ�£���ͭ������߸��˼�¼*/
int int_Record_AdvancedMode_hell;                                                /*����ģʽ�£�����������߸��˼�¼*/
int int_Record_AdvancedMode_heaven;                                              /*����ģʽ�£�����������߸��˼�¼ */ /*�ļ����������� ���մ�˳��*/
int int_Score;                                                                   /*��¼ÿ����Ϸ�ķ���*/
FILE *fp;                                                                        /*�ļ�ָ�룬�򿪺ͼ�¼����*/
Mapspots  BronzeMap[66];                                                         /*��������Ϸ��ʼʱ �洢��Ϸ��ͼ ��ͭ��(�����Ѷ�)��ͼ*/
Mapspots  hellMap[72];                                                           /*��������Ϸ��ʼʱ �洢��Ϸ��ͼ ������(�м��Ѷ�)��ͼ*/
Mapspots  HeavenMap[100];                                                        /*��������Ϸ��ʼʱ �洢��Ϸ��ͼ ������(�߼��Ѷ�)��ͼ*/
/**********************************************************************************************************************/
int main(int argc, char *argv[])
{
	PlaySound(TEXT("beijing2.wav"), NULL, SND_FILENAME | SND_ASYNC | SND_LOOP);/*��������*/
	SetConsoleTitleA("̰����");/*�ı䴰��ı���*/
	CreateMapDate();/*��ʼ����ͼ*/
	InitialInterface();/*��ʼ��Ϸ����  �ṩģʽѡ�� ��¼�鿴 ��Ϸ�˳��ӿ�*/
}
void InitialInterface()/*��ʼ��Ϸ����  �ṩģʽѡ�� ��¼�鿴 ��Ϸ�˳��ӿ�*/
{
	system("cls");
	ReadPersonalRecord();
	char getsclear[30];
	char char_Mode_Shoose;
	Loop(7, "\n");
	Loop(4, "\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);	//������ɫ 
	Loop(60, "-");
	Loop(2, "\n");Loop(18, "   ");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	printf("�� ��̰ �� �ߡ� ��\n\n");
	Loop(5, " ");
	Loop(6, "\t");
	printf("       1.����̰����\n");
	Loop(6, "\t");
	printf("       2.ͦ����̰����\n");
	Loop(6, "\t");
	printf("       3.���˼�¼\n");
	Loop(6, "\t");
	printf("       4.�����ĵ�\n");
	Loop(6, "\t");
	printf("       5.�˳���Ϸ\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);/*����������ɫ*/
	Loop(4, "\t");
	Loop(60, "-");Loop(1, "\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	Loop(4, "\t");
	printf("��������Ϸָ�");
	scanf("%c",&char_Mode_Shoose); /*ѡ����Ϸģʽ*/
	switch (char_Mode_Shoose)
	{
		case '1': 
			{
				int int_Difficulty = ClassicModeInterface();/*int_Difficulty �Ѷȵȼ� Լ��ֵΪ 1��2��3*/
				ClassicModeGameStart(int_Difficulty);
                
			} break;
		case '2': 
			{
				AdvancedModeInterface();
		    }break;
		case '3': PersonalRecordView();break;
		case '4':HelpDocumentation();break;/*�򿪰����ĵ�*/
		case '5': exit(0);
		default: {
			system("cls");
			gets(getsclear);/*��ջ���*/
			InitialInterface();/*�򿪲˵�����*/
		}
		break;
	}
}
int  ClassicModeInterface()
{
	fflush(stdin);/*��ջ���*/
	system("cls");
	int int_Difficulty;/*ѡ��ǰģʽ�µ���Ϸ�Ѷȣ����ݸ���ӡ����������ˢ��ʱ��*/
	char getsclear[30];
	Loop(8, "\n");
	Loop(5, "\t");
	Loop(38, "*");
	Loop(1, "\n");
	Loop(5, "\t");
	printf("\t�� �� ����ģʽ �� ��\n");
	Loop(1, "\n");
	Loop(6, "\t");
	printf("   1. �� ����ģʽ\n");
	Loop(6, "\t");
	printf("   2. �� �˼�ģʽ\n");
	Loop(6, "\t");
	printf("   3. �� ����ģʽ\n");
	Loop(6, "\t");
	printf("   4. �� ���ز˵�\n");
	Loop(5, "\t");
	Loop(38, "*");
	Loop(1, "\n");
	Loop(5, "\t");
	printf("��������Ϸָ�");
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
	int int_SleepTime;/*����ˢ��ʱ��*/
	if (int_Difficulty == 1) int_SleepTime = 50;
	else if (int_Difficulty == 2) int_SleepTime = 150;
	else if (int_Difficulty == 3) int_SleepTime = 300;
	else
	{
		printf(" error 01: �������ݴ���Ӧ������ �ַ� 1 ��2�� 3");
		system("pause");
		exit(1);
	}
	/*��ʼ���ߵĽṹ������*/
	for (int_Loop = 0;int_Loop<1056;int_Loop++)
	{
		snake[int_Loop].column = -1;
		snake[int_Loop].Line = -1;
		snake[int_Loop].Statu = 0;
		snake[int_Loop].Direction = ' ';
	}
	/*��ʼ��ʳ��*/
	foods.Line = -1;
	foods.Column = -1;
	foods.status = 0;
	ProductFirst(snake,NULL);/*��ʼ����λ��*/
	ProductFood(snake, &foods);/*��ʼ��ʳ��λ��*/
	GameMapPrint(snake, &foods);/*��ӡ��ͼ�ͣ�����ʳ��ĳ���λ��*/
	if(int_SleepTime==50) Sleep(2000);/*��ͣ���룬�Ա��û��ҵ��Լ���λ��*/
	while (1)
	{
		Snakes snaketail=MoveSnake(snake);  /*�ƶ�����*/
		ProductFood(snake, &foods);/*ʳ���������*/
		CollisionCheck(snake, int_Difficulty);/*��ײ��⺯��*/
		EatTheFood(&foods, snake);/*��ʳ���жϺ���*/
		GameInterfacePrint(snake, snaketail,&foods, int_SleepTime);/*��ӡ��Ϸ����*/
	}

}
void ProductFood(Snakes *snake,Food *foods)/*��������ģʽ�µ��ĵ�*/
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
		foods->status = 1;/*��ʱʳ�����*/
	}
}
void GameInterfacePrint(Snakes *snake,Snakes snaketail,Food *foods,int int_SleepTime)
{
	/*���������ͷ��λ�ã���ӡΪ��ͷ�����������β��λ�ô�ӡΪ�շ��� �������ʳ���λ�ú�״̬�����δ���Ե����ӡʳ���λ��*/
	int int_Loop, int_Countsnake=0;
	if (foods->status == 1)
	{
		GPS((*foods).Line, (*foods).Column);
		int int_food_style=GetRandomValue(4);
		if (int_food_style==1) printf("��");
		else if (int_food_style == 2) printf("��");
		else if (int_food_style == 3) printf("��");
		else if (int_food_style == 4) printf("��");
	}
	for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*�ж�����ĳ���*/
	{
		int_Countsnake++;
	}
	GPS(snake[0].Line, snake[0].column);
	printf("��");
	if (snake[0].Line!=snaketail.Line || snake[0].column!=snaketail.column)/*�����ʱ��ͷ��λ�� Ϊ֮ǰ��ͷ��λ�ã��򲻴�ӡΪ�ո񣬷�ֹ������ʧ*/
	{
		GPS(snaketail.Line, snaketail.column);
		printf("��");
	}
	GPS(25, 0);
	printf("�÷֣�%d",score);
	Sleep(int_SleepTime);
}
void GameMapPrint(Snakes *snake, Food *foods)/*��������ģʽ�µ���Ϸ��ͼ*/
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
			if (boundary[int_X][int_Y] == 1) printf("��");
			else if (boundary[int_X][int_Y] == 2) printf("��");
			else if (boundary[int_X][int_Y] == 4)   printf("��");
			else if (boundary[int_X][int_Y] == 3) printf("��");
			else if (boundary[int_X][int_Y] == 7) printf("��");
			else if (boundary[int_X][int_Y] == 8) printf("��");
			else if (boundary[int_X][int_Y] == 9) printf("��");
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
		if (snake[0].Direction == 'W') {  /*1.Ĭ��Ϊ���Ϸ���*/
			MoveUp(snake);
		}
		else if (snake[0].Direction == 'S') { /*2.Ĭ��Ϊ���·���*/
			MoveDown(snake);
		}
		else if (snake[0].Direction == 'A') {/*3.Ĭ�Ϸ���������*/
			MoveLift(snake);
		}
		else if (snake[0].Direction == 'D') {/*Ĭ�Ϸ������ҷ���*/
			MoveRight(snake);
		}
	}
	return Snakestail;
}
/*�����ƶ� �в��� �м�һ ����������� �����ƶ�ʱ�����������ƶ� �����ʱΪ��ͣ*/
void MoveUp(Snakes *snake)
{
	if (snake[0].Direction != 'S')
	{
		int int_Loop, int_Count = 0;
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*�ж�����ĳ���*/
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
/*�����ƶ� �б��в��� ����������� �����ƶ�ʱ�����������ƶ� �����ʱΪ��ͣ*/
void MoveDown(Snakes *snake)
{
	if (snake[0].Direction != 'W')
	{
		int int_Loop, int_Count = 0;
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*�ж�����ĳ���*/
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
/*���� �ƶ� �в��䣬��-1 ���� �������뷨�����ƶ�*/
void MoveLift(Snakes *snake)
{
	if (snake[0].Direction != 'D')
	{
		int int_Loop, int_Count = 0;
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*�ж�����ĳ���*/
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
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*�ж�����ĳ���*/
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
	/*�����ǽ*/
	/*���к�Ϊ0��24ʱ �� ��Ϊ0��44ʱ ײǽ*/
	if (snake[0].column == 0 || snake[0].column == 44 ||
		snake[0].Line == 0 || snake[0].Line == 24)
	{
		QuitGame(int_difficulty);
	}
	/*��ײ�Լ����*/
	for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*�ж�����ĳ���*/
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
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*�ж�����ĳ��� �õ����ڵ���β��λ�� �Ա�õ���β�ķ���*/
		{
			int_Count++;
		}
		switch (snake[int_Count - 1].Direction)
		{
		case 'W':
		{
			snake[int_Count].Statu = 1;/*������һ���ڵ�*/
			snake[int_Count].Line = snake[int_Count - 1].Line + 1;
			snake[int_Count].column = snake[int_Count - 1].column;
			snake[int_Count].Direction = 'W';
		}
		break;
		case 'S':
		{
			snake[int_Count].Statu = 1;/*������һ���ڵ�*/
			snake[int_Count].Line = snake[int_Count - 1].Line - 1;
			snake[int_Count].column = snake[int_Count - 1].column;
			snake[int_Count].Direction = 'S';
		}
		break;
		case 'A':
		{
			snake[int_Count].Statu = 1;/*������һ���ڵ�*/
			snake[int_Count].Line = snake[int_Count - 1].Line;
			snake[int_Count].column = snake[int_Count - 1].column + 1;
			snake[int_Count].Direction = 'A';
		}
		break;
		case 'D':
		{
			snake[int_Count].Statu = 1;/*������һ���ڵ�*/
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
	if(score<10)                      printf("*            ��ǰ�ɼ���%d               *\n",score);
	else if (score>=10 && score<100)  printf("*            ��ǰ�ɼ���%d              *\n", score);
	else if (score>100 && score<1000) printf("*            ��ǰ�ɼ���%d             *\n", score);
	else if (score>=1000)             printf("*            ��ǰ�ɼ���%d            *\n", score);
	/*��¼�Ƿ��޸ĵ��ж�*/
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
		printf("*            ��ϲ�㣡�¼�¼��          *\n");
	}
	Loop(5, "\t");
	printf("*            �����������˵���          *\n");
	Loop(5, "\t");
	Loop(40, "*");
	score = 0;
	printf("\n");
	Loop(5, "\t");
	WritePersonalRecord();
	system("pause");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);/*�ָ���ɫ*/
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
	Loop(25, "��");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	printf("\n\n");
	Loop(6, "\t");
	printf("�� �����ģʽ�� ��\n\n");
	Loop(6, "\t");
	printf("1.�� �߼����\n");
	Loop(6, "\t");
	printf("2.�� �м����\n");
	Loop(6, "\t");
	printf("3.�� �ͼ����\n");
	Loop(6, "\t");
	printf("4.�� ���ز˵�\n\n");
	Loop(4, "\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);
	Loop(25, "��");
	printf("\n");
	Loop(4, "\t");
	printf("��������Ϸ�ȼ�:");
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
		/*��ʼ��ʳ��*/
		foods.Line = -1;
		foods.Column = -1;
		foods.status = 0;
		system("color 70");
		AdvancedModeProductFirst(snake, 6);					     /*�����ߵĳ�ʼλ��*/
		AdvancedModeProductFood(snake, &foods, 6);			     /*����ʳ��ĳ�ʼλ��*/
		AdvancedModeHeavenGameMapPrint(snake, &foods);			 /*������Ϸ��ͼ*/
		Sleep(2000);										     /*��ͣ����*/
		while (1)
		{
			Snakes snaketail = MoveSnake(snake);                 /*�ƶ�����*/
			AdvancedModeProductFood(snake, &foods, 6);           /*ʳ�����*/
			AdvancedCollisionCheck(snake, 6);                    /*��ײ���*/
			EatTheFood(&foods, snake);                           /*��ʳ��*/
			GameInterfacePrint(snake, snaketail, &foods, 150);   /*��Ϸ�����ӡ*/
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
		/*��ʼ��ʳ��*/
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
		/*��ʼ��ʳ��*/
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
	/*��ӡ�ߵ�λ�ú�ʳ���λ��*/
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
			if (boundary[int_X][int_Y] == 1) printf("��");
			else if (boundary[int_X][int_Y] == 2) printf("��");
			else if (boundary[int_X][int_Y] == 4)   printf("��");
			else if (boundary[int_X][int_Y] == 3) printf("��");
			else if (boundary[int_X][int_Y] == 7) printf("��");
			else if (boundary[int_X][int_Y] == 8) printf("��");
			else if (boundary[int_X][int_Y] == 9) printf("��");
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
	foods->status = 1;/*��ʱʳ�����*/
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
		/*�����ǽ*/
		/*���к�Ϊ0��24ʱ �� ��Ϊ0��44ʱ ײǽ*/
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
		/*��ײ�Լ����*/
		for (int_Loop = 0;snake[int_Loop].Statu == 1;int_Loop++) /*�ж�����ĳ���*/
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
			if (boundary[int_X][int_Y] == 1) printf("��");
			else if (boundary[int_X][int_Y] == 2) printf("��");
			else if (boundary[int_X][int_Y] == 4)   printf("��");
			else if (boundary[int_X][int_Y] == 3) printf("��");
			else if (boundary[int_X][int_Y] == 7) printf("��");
			else if (boundary[int_X][int_Y] == 8) printf("��");
			else if (boundary[int_X][int_Y] == 9) printf("��");
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
	for (int_X = 0;int_X<25;int_X++)/*��ӡ��Ϸ��ͼ ����Ҫ������ ���*/
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
	if ((*foods).status == 1)/*���ʳ��״̬��1 ��ʳ��û�б��Ե� ���ӡ��ʳ��*/
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
			if (boundary[int_X][int_Y] == 1) printf("��");
			else if (boundary[int_X][int_Y] == 2) printf("��");
			else if (boundary[int_X][int_Y] == 4)   printf("��");
			else if (boundary[int_X][int_Y] == 3) printf("��");
			else if (boundary[int_X][int_Y] == 7) printf("��");
			else if (boundary[int_X][int_Y] == 8) printf("��");
			else if (boundary[int_X][int_Y] == 9) printf("��");
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
	printf("\n\t\t\t\t\t\t�� �� ���ս�� �� ��\n\t\t\t\t\t");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	printf("   ����ģʽ�� 1.���� :%d",int_Record_ClassicMode_difficulty);
	printf("\n\t\t\t\t\t\t      2.�˼䣺%d", int_Record_ClassicMode_secondary);
	printf("\n\t\t\t\t\t\t      3.���ã�%d", int_Record_ClassicMode_easy);
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);
	printf("\n\t\t\t\t\t   ����ģʽ�� 1.�߼� :%d", int_Record_AdvancedMode_heaven);
	printf("\n\t\t\t\t\t\t      2.�е� :%d", int_Record_AdvancedMode_hell);
	printf("\n\t\t\t\t\t\t      3.���� :%d\n", int_Record_AdvancedMode_bronze);
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);
	Loop(5, "\t");	Loop(35, "-");
	printf("\n");
	Loop(5, "\t");
	system("pause");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
	InitialInterface();/*���ؽ���*/


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
	/*���ļ��ж�����Ϸ��¼*/
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
	Loop(3, "��������");
	printf("\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 11);
	Loop(5, "\t");
	printf("\t  �� �� �� ˵���� �� �� ��\n\n");
	Loop(5, "\t");
	printf("\t\t ���Ʒ���\t\t\n");
	Loop(5, "\t");
	printf("\t ��:W  ��:S  ��:A  ��:D\t\n");
	Loop(5, "\t");
	printf("\t\t��Ϸ�����ж�\t\t\n");
	Loop(5, "\t");
	printf("\t�������߽�����Լ�����Ϸ����\t\n");
	Loop(5, "\t");
	printf("\t�������ﵽһ��ʱ��Ϸ����\t\n\n");
	Loop(5, "\t");
	printf("    ��     ���غ���ʱ�밴�س�!      ��\n");
	Loop(5, "\t");
	printf("    �� ��Ϸ��ͣ���������Ϸ���棡 ��\n");
	Loop(5, "\t");
	printf("    �� ���Ѷ���Ϸ��ʼʱ����ͣ���룡 ��\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 12);/*���ñ���ɫ*/
	Loop(5, "\t");
	Loop(3, "��������");
	printf("\n");Loop(5, "\t");
	system("pause");
	InitialInterface();
}
int  GetRandomValue(int int_Max)/*���������*/
{
	srand((unsigned int)time(NULL));
	return rand() % int_Max + 1;
}
void Loop(int int_loop, char Str[20])
{
	int loop;
	for (loop = 0;loop<int_loop;loop++) printf("%s", Str);
}
void GPS(int x, int y)//��λ���λ��
{
	COORD pos;
	HANDLE hOutput;
	pos.X = y * 2+10;
	pos.Y = x+3;
	hOutput = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCursorPosition(hOutput, pos);
}