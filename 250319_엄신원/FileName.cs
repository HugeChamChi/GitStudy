using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace _250319_엄신원
{
    

    class Program
    {
        struct Position
        {
            public int x;
            public int y;
        }

        static void Main(string[] args)
        {
                       

            char[,] stage1Map = new char[15, 21]
            {
                 { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒' },
                 { '▒', 'P', '▒', 'K', ' ', ' ', ' ', ' ', '■', '■','■','■',' ',' ',' ',' ',' ',' ',' ','E','▒' },
                 { '▒', ' ', '▒', '▒', '▒', '■', '▒', ' ', ' ', ' ',' ','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒' },
                 { '▒', ' ', ' ', ' ', ' ', ' ', '▒', '▒', '■', '▒',' ','▒','R',' ','▒',' ',' ',' ',' ',' ','▒' },
                 { '▒', '▒', ' ', '▒', '▒', '▒', ' ', ' ', ' ', '▒',' ','▒','▒',' ','▒','▒',' ','▒','▒','▒','▒' },
                 { '▒', ' ', ' ', '▒', ' ', ' ', ' ', '▒', '▒', ' ',' ','▒',' ',' ',' ',' ',' ','▒','▒','▒','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', '▒', '▒', ' ', ' ','▒','▒','▒',' ','▒','▒',' ',' ',' ',' ','▒' },
                 { '▒', ' ', '▒', ' ', '▒', ' ', '▒', '▒', ' ', '▒','▒','▒',' ',' ',' ',' ',' ','▒','▒',' ','▒' },
                 { '▒', ' ', '▒', ' ', '▒', ' ', '▒', '▒', ' ', '▒','▒','▒','▒','▒','▒','▒',' ','▒','▒',' ','▒' },
                 { '▒', ' ', ' ', ' ', '▒', ' ', '▒', '▒', ' ', '▒','▒','▒',' ',' ',' ','▒',' ','▒','▒',' ','▒' },
                 { '▒', '▒', '▒', '▒', '▒', ' ', '▒', '▒', ' ', ' ','▒','▒',' ','▒',' ','▒',' ','▒','▒',' ','▒' },
                 { '▒', 'D', '▒', ' ', ' ', ' ', ' ', ' ', '▒', ' ','▒','▒',' ','▒',' ','▒',' ','▒','▒','.','▒' },
                 { '▒', ' ', '▒', '▒', ' ', '▒', '▒', ' ', '▒', ' ','■',' ',' ','▒',' ','▒',' ','▒','▒','▒','▒' },
                 { '▒', ' ', ' ', ' ', ' ', '▒', '▒', ' ', ' ', ' ','▒','▒','▒','▒',' ',' ',' ',' ',' ',' ','▒' },
                 { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒' }
            };

            char[,] stage2Map = new char[15, 21]
            {
                 { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒' },
                 { '▒', '.', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','▒' },
                 { '▒', ' ', '▒', '▒', '▒', '▒', ' ', '▒', ' ', '▒',' ',' ',' ',' ','▒',' ','▒',' ',' ',' ','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒','▒',' ',' ',' ','▒',' ','▒','▒',' ',' ','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', '▒', ' ', '▒','▒',' ',' ',' ','▒',' ','▒','▒','▒','.','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', '▒', ' ', '▒',' ','▒',' ',' ','▒',' ','▒',' ','▒',' ','▒' },
                 { '▒', ' ', '▒', '.', ' ', ' ', ' ', '▒', ' ', '▒',' ','▒',' ',' ','▒',' ','▒',' ',' ','▒','▒' },
                 { '▒', ' ', '▒', '▒', '▒', '▒', ' ', '▒', ' ', '▒',' ',' ','▒',' ','▒',' ','▒',' ',' ','▒','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', '▒', ' ', '▒',' ',' ','▒',' ','▒',' ','▒',' ',' ','▒','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', '▒', ' ', '▒',' ',' ',' ','▒','▒',' ','▒',' ',' ','▒','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', '▒', ' ', '▒',' ',' ',' ','▒','▒',' ','▒',' ','▒',' ','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', '▒', ' ', '▒',' ',' ',' ',' ','▒',' ','▒','▒','▒','P','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', '▒', ' ', '▒',' ',' ',' ',' ','▒',' ','▒','▒',' ',' ','▒' },
                 { '▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','▒' },
                 { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒' }
            };

            int currentStage = 1;
            char[,] currentMap = stage1Map;
            Position playerpos = new Position { x = 1, y = 1 };
            bool hasKey = false;
            bool gameOver = false;
            int turnLeft = 120;
            Position stage2goal = new Position { x = 1, y = 1 };
            // 게임 루프 만들기
            while (!gameOver)
            {
                Console.Clear();
                Render(currentMap, turnLeft, currentStage);

                // 남은턴이 없다면 ? 

                if (turnLeft <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(" 게임 오버 ");
                    break;

                }
                // 사용자 키 입력 받기
                ConsoleKey key = Console.ReadKey(true).Key;
                Move(key, ref playerpos, currentMap, ref hasKey, ref gameOver,currentStage,stage2goal);

                turnLeft--;


                if (gameOver && currentStage == 1)
                {
                    Console.Clear();

                    currentStage++;
                    currentMap = stage2Map;
                    playerpos = new Position { x = 19, y = 11 };
                    turnLeft = 40;
                    hasKey = false;
                    gameOver = false;

                }
                else if (gameOver && currentStage == 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("축하드립니다 모든 스테이지 클리어하셨습니다.");
                        Thread.Sleep(500);

                        Console.Clear();
                        Thread.Sleep(500);

                    }
                    break;
                }


            }

        }

        // 남은턴 화면 출력하기 
        
        static void Render(char[,] map, int turnLeft,int currentStage)
        {
            Console.WriteLine($" 남은 턴 : {turnLeft}; 열쇠를 찾고 이상한 점을 찾아 (E)scape 하세요.");
            Console.WriteLine();


            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if(currentStage == 2 && map[y,x] =='.')
                    {
                        if (x == 1 && y == 1) Console.ForegroundColor = ConsoleColor.Red;
                        else if (x == 3 && y == 6) Console.ForegroundColor = ConsoleColor.Green;
                        else if (x == 19 && y == 4) Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(map[y, x]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(map[y, x]);
                    }
                }   
                
                    Console.WriteLine();
            }

        }

        static void Move(ConsoleKey key, ref Position playerPos, char[,] map,ref bool hasKey,ref bool gameOver,int currentStage, Position stage2Goal)
        {   // 위치 초기화
            Position targetPos = playerPos;

            switch(key)
            {
                case ConsoleKey.W: targetPos.y--; break;
                case ConsoleKey.S: targetPos.y++; break;
                case ConsoleKey.A: targetPos.x--; break;
                case ConsoleKey.D: targetPos.x++; break;
                default: return;

            }

            // 타일 상태 확인 .
            char targetTile = map[targetPos.y, targetPos.x];
            // 만약 공백이라면 ? 
            if(targetTile == ' ')
            {
                map[playerPos.y, playerPos.x] = ' ';  // 이전 위치를 공백으로 변경
                playerPos = targetPos;                // 플레이어 위치 업데이트
                map[playerPos.y, playerPos.x] = 'P';  // 새로간 위치에 플레이어표시

            }
            else if (targetTile == 'K')
            {   // 키를 먹었을시 hasKey=true 로 변경하여 로직생성
                hasKey = true;
                map[playerPos.y, playerPos.x] = ' ';
                playerPos = targetPos;
                map[playerPos.y, playerPos.x] = 'P';

                RemoveWall(map);
            }
            else if (targetTile == '.')
            {
                gameOver = true;
            }
            
           


        }

        // 훼이크 주려고 .를 했는데 너무 잘보이네요 
        static void RemoveWall(char[,]map)
        {
            map[1, 8] = ' ';
            map[1, 9] = ' ';
            map[1, 10] = ' ';
            map[1, 11] = ' ';
            map[2, 5] = ' ';
            map[3, 8] = ' ';
            map[12, 10] = ' ';
            
           
        }
    }

}

