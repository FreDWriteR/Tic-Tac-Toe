using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tic_Tac : MonoBehaviour
{
    public GameObject X;
    public GameObject Zero;
    public MeshRenderer renderer1;
    public MeshRenderer renderer2;
    public SortedSet<int> X_Steps = new SortedSet<int>();
    public SortedSet<int> Zero_Steps = new SortedSet<int>();
    public SortedSet<int> SetSize = new SortedSet<int>();
    public SortedSet<int> ZeroSect = new SortedSet<int>();
    public SortedSet<int> ZeroSect1 = new SortedSet<int>();
    public SortedSet<int> XSect = new SortedSet<int>();
    public SortedSet<int> XSectAngle = new SortedSet<int>();
    public SortedSet<int> ZeroSectAngle = new SortedSet<int>();
    public SortedSet<int> ExceptX = new SortedSet<int>();
    public SortedSet<int> ExceptZero = new SortedSet<int>();
    public List<SortedSet<int>> WinSets = new List<SortedSet<int>>();
    public IEnumerator coroutine;
    public SortedSet<int> GameField = new SortedSet<int> {0, 1, 2, 3, 4, 5, 6, 7, 8};
    public SortedSet<int> GameField5 = new SortedSet<int> { 0, 1, 2, 3, 4, 
                                                            5, 6, 7, 8, 9,
                                                            10, 11, 12, 13, 14,
                                                            15, 16, 17, 18, 19,
                                                            20, 21, 22, 23, 24 };
    public SortedSet<string> X_Zero = new SortedSet<string>();
    public SortedSet<int> ZeroPath = new SortedSet<int>();
    public SortedSet<int> intExceptX = new SortedSet<int>();
    public SortedSet<int> intExceptZero = new SortedSet<int>();
    public int intsect = 0, intsectTemp = 0, size = 3, ShortPathTemp = 0, countDeadlock = 0;
    public string StepName, TempStep, Zero_One;
    public bool first = true, GameOver = false, Men1XMachine = false, MenXMachine1 = false, bDemo = false, fistsStepForSecond = true, fistsStepDemo = true;
    public GameObject X_Zero_Clone;
    public Vector3 Position;
    public GameObject[] Steps;
    public GameObject[] Row;
    //SortedSet<List<string>> WinSets = new SortedSet<List<string>>();
    //public ArrayList<SortedSet<string>> WinSets = new SortedSet<string>>();
    //public WinSets = new SortedSet
    // Start is called before the first frame update


    

    void Start()
    {
        X = GameObject.Find("X");
        renderer1 = X.GetComponent<MeshRenderer>();
        renderer1.enabled = false;
        Zero = GameObject.Find("Zero");
        renderer2 = Zero.GetComponent<MeshRenderer>();
        renderer2.enabled = false;

        

        if (size == 3) { 
            WinSets.Add(new SortedSet<int> { 0, 1, 2 });
            WinSets.Add(new SortedSet<int> { 3, 4, 5 });
            WinSets.Add(new SortedSet<int> { 6, 7, 8 });
            WinSets.Add(new SortedSet<int> { 0, 3, 6 });
            WinSets.Add(new SortedSet<int> { 1, 4, 7 });
            WinSets.Add(new SortedSet<int> { 2, 5, 8 });
            WinSets.Add(new SortedSet<int> { 0, 4, 8 });
            WinSets.Add(new SortedSet<int> { 2, 4, 6 });
        }
        if (size == 4)
        {
            int j = 0;
            int k = 0;
            int o = 0;
            for (int i = 0; i < 5; i++)
            {
                Row = GameObject.FindGameObjectsWithTag("Row" + (i + 1));
                GameObject G;   
                foreach (GameObject R in Row)
                {
                    G = R;
                    while (G.transform.childCount > 0)
                    {
                        G = G.transform.GetChild(0).gameObject;
                        k++;
                    }
                    if (k > 0 && int.Parse(R.tag.Substring(3, 1)) < 5)
                    {
                        j = 4 - k;
                        o = int.Parse(R.gameObject.tag.Substring(3, 1));
                        R.name = "Field" + ((k + 2 + j) * i + j - i * 2).ToString();
                        R.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else
                    {
                        R.GetComponent<MeshRenderer>().enabled = false;
                        R.name = "Field90" + (i).ToString() + (j).ToString();
                    }
                    k = 0;
                }
            }
            WinSets.Add(new SortedSet<int> { 0, 1, 2, 3});
            WinSets.Add(new SortedSet<int> { 4, 5, 6, 7 });
            WinSets.Add(new SortedSet<int> { 8, 9, 10, 11 });
            WinSets.Add(new SortedSet<int> { 12, 13, 14, 15 });
            WinSets.Add(new SortedSet<int> { 0, 4, 8, 12 });
            WinSets.Add(new SortedSet<int> { 1, 5, 9, 13 });
            WinSets.Add(new SortedSet<int> { 2, 6, 10, 14 });
            WinSets.Add(new SortedSet<int> { 3, 7, 11, 15 });
            WinSets.Add(new SortedSet<int> { 0, 5, 10, 15 });
            WinSets.Add(new SortedSet<int> { 3, 6, 9, 12 });
        }
        if (size == 5)
        {
            int j = 0;
            int k = 0;
            int o = 0;
            for (int i = 0; i < 5; i++) {
                Row = GameObject.FindGameObjectsWithTag("Row" + (i + 1));
                GameObject G;
                foreach (GameObject R in Row)
                {
                    G = R;
                    while (G.transform.childCount > 0)
                    {
                        G = G.transform.GetChild(0).gameObject;
                        k++;
                    }
                    j = 4 - k;
                    o = int.Parse(R.gameObject.tag.Substring(3, 1));
                    R.name = "Field" + ((k + 1 + j) * i + j).ToString();
                    k = 0;
                    R.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            WinSets.Add(new SortedSet<int> { 0, 1, 2, 3, 4 });
            WinSets.Add(new SortedSet<int> { 5, 6, 7, 8, 9 });
            WinSets.Add(new SortedSet<int> { 10, 11, 12, 13, 14 });
            WinSets.Add(new SortedSet<int> { 15, 16, 17, 18, 19 });
            WinSets.Add(new SortedSet<int> { 20, 21, 22, 23, 24 });
            WinSets.Add(new SortedSet<int> { 0, 5, 10, 15, 20 });
            WinSets.Add(new SortedSet<int> { 1, 6, 11, 16, 21 });
            WinSets.Add(new SortedSet<int> { 2, 7, 12, 17, 22 });
            WinSets.Add(new SortedSet<int> { 3, 8, 13, 18, 23 });
            WinSets.Add(new SortedSet<int> { 4, 9, 14, 19, 24 });
            WinSets.Add(new SortedSet<int> { 0, 6, 12, 18, 24 });
            WinSets.Add(new SortedSet<int> { 4, 8, 12, 16, 20 });
        }
    }

    void ClearGame()
    {
        X_Steps.Clear();
        Zero_Steps.Clear();
        SetSize.Clear();
        X_Zero.Clear();
        WinSets.Clear();
        first = true;
        GameOver = false;
        Men1XMachine = false;
        MenXMachine1 = false;
        bDemo = false;
        fistsStepForSecond = true;
        fistsStepDemo = true;
        if (X_Zero_Clone)
        {
            Destroy(X_Zero_Clone.gameObject);
        }
        Steps = GameObject.FindGameObjectsWithTag("Steps");
        foreach (GameObject Step in Steps)
        {
            if (Step.name != "X" && Step.name != "Zero")
            {
                Destroy(Step);
            }
        }

    }

    void StepMachineFirst()
    {
        Position = GameObject.Find("Field4").gameObject.transform.position;
        X_Zero_Clone = Instantiate(X, Position, Quaternion.identity) as GameObject;
        X_Zero_Clone.name = "X4";
        X_Steps.Add(int.Parse(X_Zero_Clone.name.Substring(1, (X_Zero_Clone.name.Length - 1))));
        X_Zero_Clone.GetComponent<MeshRenderer>().enabled = true;
        X_Zero.Add(X_Zero_Clone.name);
        first = false;
    }

    void StepMachineFirst5()
    {
        Position = GameObject.Find("Field12").gameObject.transform.position;
        X_Zero_Clone = Instantiate(X, Position, Quaternion.identity) as GameObject;
        X_Zero_Clone.name = "X12";
        X_Steps.Add(int.Parse(X_Zero_Clone.name.Substring(1, (X_Zero_Clone.name.Length - 1))));
        X_Zero_Clone.GetComponent<MeshRenderer>().enabled = true;
        X_Zero.Add(X_Zero_Clone.name);
        first = false;
    }

    void StepMachineFirst4()
    {
        Position = GameObject.Find("Field0").gameObject.transform.position;
        X_Zero_Clone = Instantiate(X, Position, Quaternion.identity) as GameObject;
        X_Zero_Clone.name = "X0";
        X_Steps.Add(int.Parse(X_Zero_Clone.name.Substring(1, (X_Zero_Clone.name.Length - 1))));
        X_Zero_Clone.GetComponent<MeshRenderer>().enabled = true;
        X_Zero.Add(X_Zero_Clone.name);
        first = false;
    }

    void StepMachineContinue()
    {
        Position = GameObject.Find("Field" + StepName).gameObject.transform.position;
        if (MenXMachine1)
        {
            X_Zero_Clone = Instantiate(X, Position, Quaternion.identity) as GameObject;
            X_Zero_Clone.name = "X" + StepName;
            X_Steps.Add(int.Parse(X_Zero_Clone.name.Substring(1, (X_Zero_Clone.name.Length - 1))));
            first = false;
        }
        else
        {
            X_Zero_Clone = Instantiate(Zero, Position, Quaternion.identity) as GameObject;
            X_Zero_Clone.name = "Zero" + StepName;
            Zero_Steps.Add(int.Parse(X_Zero_Clone.name.Substring(4, (X_Zero_Clone.name.Length - 4))));
            first = true;
        }
        X_Zero_Clone.GetComponent<MeshRenderer>().enabled = true;
        X_Zero.Add(X_Zero_Clone.name);

    }

    private IEnumerator Demo()
    {
        MenXMachine1 = true;
        while (!GameOver) {
            if (fistsStepDemo) {
                size = 5;
                
                StepMachineFirst5();
                yield return new WaitForSeconds(0.5f);
                fistsStepDemo = false;
                MenXMachine1 = false;
            }
            else
            {
                if (!first)
                {
                    if (fistsStepForSecond)
                    {
                        MachineStep1First5();
                        yield return new WaitForSeconds(0.5f);
                        fistsStepForSecond = false;
                    }
                    else
                    {
                        MachineStep5(Zero_Steps, X_Steps);
                        yield return new WaitForSeconds(0.5f);
                    }
                    first = true;
                    MenXMachine1 = true;
                }
                else
                {
                    MachineStep5(X_Steps, Zero_Steps);
                    yield return new WaitForSeconds(0.5f);
                    first = false;
                    MenXMachine1 = false;
                }

                //Сравнение сета шагов первого игрока с выигрышными сетами шагов
                if (X_Steps.Count >= size || Zero_Steps.Count >= size)
                {
                    foreach (SortedSet<int> WinSet in WinSets)
                    {
                        if (X_Steps.Count >= size)
                        {
                            SetSize = new SortedSet<int>(WinSet);
                            SetSize.IntersectWith(X_Steps); //Получение пересечения выигрышного сета с сетом крестиков 
                            if (SetSize.Count == size) //Eсли размер пересечения равен 3
                            {
                                GameObject.Find("WinX").gameObject.GetComponent<MeshRenderer>().enabled = true;
                                GameOver = true;
                                break;
                            }
                        }
                        if (Zero_Steps.Count >= size)
                        {
                            SetSize = new SortedSet<int>(WinSet);
                            SetSize.IntersectWith(Zero_Steps); //Получение пересечения выигрышного сета с сетом ноликов
                                                               
                            if (SetSize.Count == size) //Eсли размер пересечения равен 3
                            {
                                GameObject.Find("Win0").gameObject.GetComponent<MeshRenderer>().enabled = true;
                                GameOver = true;
                                break;
                            }
                        }
                    }
                    if (!GameOver && countDeadlock == WinSets.Count)
                    {
                        GameObject.Find("Draw").gameObject.GetComponent<MeshRenderer>().enabled = true;
                        GameOver = true;
                    }
                }
            }
        }
        
    }

    void Machine1Step(SortedSet<int> Steps1, SortedSet<int> Steps2) //Ход машины
    {
        foreach (SortedSet<int> WinSet in WinSets)
        {
            SetSize = new SortedSet<int>(WinSet);
            ExceptX = new SortedSet<int>(WinSet);
            ExceptZero = new SortedSet<int>(WinSet);
            XSect = new SortedSet<int>(WinSet);

            SetSize.IntersectWith(Steps2);
            XSect.IntersectWith(Steps1);

            if (XSect.Count == 2) //Если в выигрышном пути 2 хода машины и нет ходов человека 
            {
                ExceptX.ExceptWith(Steps1); //Получаем клетку выигрышного множества машины
                if (!Steps2.Contains(ExceptX.Max))
                {
                    StepName = ExceptX.Max.ToString();
                    intsect = 3;
                    break;
                }

            }
            if (SetSize.Count == 2) //Если в выигрышном пути 2 хода человека и нет ходов машины
            {
                ExceptZero.ExceptWith(Steps2); //Получаем клетку выигрышного множества человека
                if (!Steps1.Contains(ExceptZero.Max))
                {
                    StepName = ExceptZero.Max.ToString();
                    intsect = 3;
                    break;
                }

            }
            if (SetSize.Count == 1 && XSect.Count == 0) //Если в выигрышном пути 1 ход человека и нет ходов машины
            {
                Zero_One = SetSize.Max.ToString();

                //Цикл для поиска более выгодных ходов чем перекрытие пути для ходов человека
                foreach (SortedSet<int> WinSetWithin in WinSets)
                {
                    SetSize = new SortedSet<int>(WinSetWithin);
                    ZeroSect = new SortedSet<int>(WinSetWithin);
                    SetSize.IntersectWith(Steps1);
                    ZeroSect.IntersectWith(Steps2);
                    if (SetSize.Count == 1 && ZeroSect.Count == 0) //Путь где есть ходы машины и нет ходов человека
                    {
                        ExceptX = new SortedSet<int>(WinSetWithin);
                        ExceptX.ExceptWith(Steps1);
                        while (ExceptX.Count > 0)
                        {
                            foreach (SortedSet<int> WinSetWithinWithin in WinSets)
                            {
                                if (WinSetWithinWithin.Contains(ExceptX.Min))
                                {
                                    SetSize = new SortedSet<int>(WinSetWithinWithin);
                                    ZeroSect = new SortedSet<int>(WinSetWithinWithin);
                                    SetSize.IntersectWith(Steps1);
                                    ZeroSect.IntersectWith(Steps2);
                                    if (ZeroSect.Count == 0 && SetSize.Count == 1) //Если нашли свободный путь с ходами машины
                                    {
                                        intsectTemp++;
                                        TempStep = ExceptX.Min.ToString();
                                    }
                                }
                            }
                            if (intsectTemp > 1)
                            {
                                TempStep = ExceptX.Min.ToString();
                            }
                            if (intsect <= intsectTemp)
                            {
                                intsect = intsectTemp;
                                StepName = TempStep;

                            }
                            intsectTemp = 0;
                            ExceptX.Remove(ExceptX.Min);

                        }
                    }
                }
                if (intsect == 1)
                {
                    SetSize = new SortedSet<int>(WinSet);

                    if (SetSize.Max.ToString() == Zero_One)
                    {
                        StepName = SetSize.Min.ToString();
                    }
                    else if (SetSize.Min.ToString() == Zero_One)
                    {
                        StepName = SetSize.Max.ToString();
                    }
                    else
                    {
                        StepName = SetSize.Min.ToString();
                    }
                }
            }
        }
        if (intsect < 3 && intsect > 0 && Men1XMachine) { 
            for (int i = 6; i < 8; i++)
            { //Если машина ходит второй, и если человек сделал ход в угол ходим в противоположный угол, если он занят ходим на сторону
                XSectAngle = new SortedSet<int>(WinSets[i]);
                XSectAngle.IntersectWith(Steps2);
                ZeroSectAngle = new SortedSet<int>(WinSets[i]);
                ZeroSectAngle.IntersectWith(Steps1);
                if (XSectAngle.Count == 1 && ZeroSectAngle.Count == 1)
                {
                    if (XSectAngle.Max == WinSets[i].Max)
                    {
                        StepName = WinSets[i].Min.ToString();
                        intsect = 3;
                        break;
                    }
                    else
                    {
                        StepName = WinSets[i].Max.ToString();
                        intsect = 3;
                        break;
                    }

                }
                else if (XSectAngle.Count == 2) //Если противоположный угол занят идем на сторону
                {
                    for (int j = 1; j < 5; j += 3)
                    {
                        ZeroSectAngle = new SortedSet<int>(WinSets[j]);
                        ZeroSectAngle.IntersectWith(Steps1);
                        if (ZeroSectAngle.Count == 1)
                        {
                            StepName = WinSets[j].Min.ToString();
                            intsect = 3;
                            break;
                        }

                    }
                    if (intsect == 3)
                    {
                        break;
                    }
                }
            }
        }
        if (intsect == 0 && SetSize.Count == 1)
        {
            SetSize = new SortedSet<int>(Steps1);

            GameField.ExceptWith(SetSize);
            SetSize = new SortedSet<int>(Steps2);
            GameField.ExceptWith(SetSize);
            if (GameField.Count > 0) { 
                StepName = GameField.Min.ToString();
            }
        }
        StepMachineContinue();

        foreach (SortedSet<int> WinSet in WinSets) //Проверка на ничью
        {
            SetSize = new SortedSet<int>(WinSet);
            XSect = new SortedSet<int>(WinSet);
            ZeroSect = new SortedSet<int>(WinSet);
            ZeroSect.IntersectWith(Steps2);
            XSect.IntersectWith(Steps1);
            if (XSect.Count > 0 && ZeroSect.Count > 0)
            {
                countDeadlock++;
            }
        }

        if (countDeadlock == 8)
        {
            return;
        }
        countDeadlock = 0;
        
        intsect = 0;
    }

    void MachineMiniMax()
    {
        X_Steps.Add(4);
        Zero_Steps.Add(8);
        

        foreach (SortedSet<int> WinSet in WinSets)
        {
            SetSize = new SortedSet<int>(WinSet);
            ExceptX = new SortedSet<int>(WinSet);
            ExceptZero = new SortedSet<int>(WinSet);
            XSect = new SortedSet<int>(WinSet);

            SetSize.IntersectWith(Zero_Steps);
            XSect.IntersectWith(X_Steps);
            if (XSect.Count == 2) //Если в выигрышном пути 2 хода машины и нет ходов человека 
            {
                ExceptX.ExceptWith(X_Steps); //Получаем клетку выигрышного множества машины
                if (!Zero_Steps.Contains(ExceptX.Max))
                {
                    X_Steps.Add(int.Parse(StepName));
                    StepName = ExceptX.Max.ToString();
                    intsect = 3;
                    break;
                }
            }
            if (SetSize.Count == 2) //Если в выигрышном пути 2 хода человека и нет ходов машины
            {
                ExceptZero.ExceptWith(Zero_Steps); //Получаем клетку выигрышного множества человека
                if (!X_Steps.Contains(ExceptZero.Max))
                {
                    X_Steps.Add(int.Parse(StepName));
                    StepName = ExceptZero.Max.ToString();
                    intsect = 3;
                    break;
                }
            }

        }
    }

    void MachineStep1First() //Ход машины
    {
        if (!X_Steps.Contains(4)) //Если центр не занят
        {
            StepName = "4"; //Идем в центр
        }
        else
        {
            SetSize = new SortedSet<int> { 0, 2, 6, 8 };
            SetSize.ExceptWith(X_Steps); //Проверяем углы
            if (SetSize.Count > 0)
            {
                StepName = SetSize.Min.ToString(); //Идем в любой свободный угол
            }
        }
        StepMachineContinue();
    }

    void MachineStep1First4() //Ход машины
    {
        
        ExceptX = new SortedSet<int> { 0, 3, 12, 15 };
        ExceptZero = new SortedSet<int> { 0, 3, 12, 15 };
        ExceptX.ExceptWith(X_Steps); //Проверяем углы
        ExceptZero.IntersectWith(Zero_Steps); //Проверяем углы
        ExceptX.ExceptWith(ExceptZero);
        if (ExceptX.Count > 0 )
        {
            StepName = ExceptX.Min.ToString(); //Идем в любой свободный угол
        }
        StepMachineContinue();
    }

    void MachineStep1First5() //Ход машины
    {
        if (!X_Steps.Contains(12)) //Если центр не занят
        {
            StepName = "12"; //Идем в центр
        }
        else
        {
            SetSize = new SortedSet<int> { 0, 4, 20, 34 };
            SetSize.ExceptWith(X_Steps); //Проверяем углы
            if (SetSize.Count > 0)
            {
                StepName = SetSize.Min.ToString(); //Идем в любой свободный угол
            }
        }
        StepMachineContinue();
    }


    /////////////////////////////////////////////////////////
    //Метод анализа для хода машины при игре c размерностью 5//
    /////////////////////////////////////////////////////////
    void MachineStep5(SortedSet<int> Steps1, SortedSet<int> Steps2)
    {
        foreach (SortedSet<int> WinSet in WinSets)
        {
            SetSize = new SortedSet<int>(WinSet);
            ExceptX = new SortedSet<int>(WinSet);
            ExceptZero = new SortedSet<int>(WinSet);
            XSect = new SortedSet<int>(WinSet);
            
            SetSize.IntersectWith(Steps2);
            XSect.IntersectWith(Steps1);

            if (XSect.Count == size - 1) //Если в выигрышном пути size - 1 ходов машины и нет ходов человека
            {
                ExceptX.ExceptWith(Steps1); //Получаем клетку выигрышного множества ходов машины
                if (!Steps2.Contains(ExceptX.Max))
                {
                    StepName = ExceptX.Max.ToString();
                    intsect = 3;
                    break;
                }

            }
            else if (SetSize.Count == size - 1) //Если в выигрышном пути size - 1 ходов человека и нет ходов машины
            {
                ExceptZero.ExceptWith(Steps2); //Получаем клетку выигрышного множества ходов человека
                if (!Steps1.Contains(ExceptZero.Max))
                {
                    StepName = ExceptZero.Max.ToString();
                    intsect = 3;
                    break;
                }

            }
            else if (SetSize.Count == 1 && XSect.Count == 0) //Если в выигрышном пути 1 ход человека и нет ходов машины (поиск хода с перекрытием пути для ходов человека)
            {
                Zero_One = SetSize.Max.ToString();

                //Цикл для поиска более выгодных ходов чем перекрытие пути для ходов человека
                foreach (SortedSet<int> WinSetWithin in WinSets)
                {
                    SetSize = new SortedSet<int>(WinSetWithin);
                    ZeroSect = new SortedSet<int>(WinSetWithin);
                    SetSize.IntersectWith(Steps1);
                    ZeroSect.IntersectWith(Steps2);
                    if (SetSize.Count < size - 1 && SetSize.Count > 0 && ZeroSect.Count == 0) //Путь где есть ходы машины и нет ходов человека
                    {
                        ExceptX = new SortedSet<int>(WinSetWithin);
                        ExceptX.ExceptWith(Steps1); //Пустые клетки в пути машины
                        while (ExceptX.Count > 0) //Пока не проверили все пустые клетки в пути машины
                        {
                            foreach (SortedSet<int> WinSetWithinWithin in WinSets) //Цикл для поиска хода с пересечением нескольких путей машины или короткого пути для машины
                            {
                                if (WinSetWithinWithin.Contains(ExceptX.Min))
                                {
                                    SetSize = new SortedSet<int>(WinSetWithinWithin);
                                    ZeroSect = new SortedSet<int>(WinSetWithinWithin);
                                    SetSize.IntersectWith(Steps1);
                                    ZeroSect.IntersectWith(Steps2);
                                    if (ZeroSect.Count == 0 && SetSize.Count < size - 1 && SetSize.Count > 0) //Если нашли свободный путь с ходами машины
                                    {
                                        intsectTemp++; //Количество свободных путей у текущей клетки с уже имеющимися ходами человека
                                        TempStep = ExceptX.Min.ToString();
                                        if (SetSize.Count > 1)
                                        {
                                            ShortPathTemp = SetSize.Count; //Путь короче size - 1
                                        }
                                    }
                                }
                            }
                            if (intsectTemp > 1 && ShortPathTemp == 0) //Если есть пересечения путей машины и нет коротких путей
                            {
                                TempStep = ExceptX.Min.ToString();
                            }

                            if (ShortPathTemp < intsectTemp && ShortPathTemp != 0) //Если короткий путь есть, но пересечение приоритетнее
                            {
                                TempStep = ExceptX.Min.ToString();
                            }
                            if (ShortPathTemp > intsect && intsect > 0) //Если короткий путь приоритетнее
                            {
                                intsect = ShortPathTemp;
                                StepName = TempStep;
                            }
                            else if (intsect < intsectTemp || (ShortPathTemp <= intsect && ShortPathTemp != 0 && ShortPathTemp <= intsectTemp)) //Если короткий путь и пересечение
                            {                                                                                                                   //имеют одинаковый приоритет
                                intsect = intsectTemp;
                                StepName = TempStep;
                            }

                            intsectTemp = 0;
                            ShortPathTemp = 0;
                            ExceptX.Remove(ExceptX.Min);

                        }
                    }
                }
                if (intsect == 1) //Если короткий путь и пересечение для путей машины не найдены
                {
                    foreach (SortedSet<int> WinSetWithin in WinSets) //Цикл для поиска хода, перекрывающего один их путей для ходов человека и, одновременно, укорачивающего путь для машины
                    {
                        ZeroSect1 = new SortedSet<int>(WinSet);
                        ZeroSect1.ExceptWith(Steps2);
                        SetSize = new SortedSet<int>(WinSetWithin);
                        XSect = new SortedSet<int>(WinSetWithin);
                        ZeroSect = new SortedSet<int>(WinSetWithin);
                        ZeroSect.IntersectWith(Steps2);
                        XSect.IntersectWith(Steps1);
                        ExceptX = new SortedSet<int>(WinSetWithin);
                        ExceptX.ExceptWith(Steps1);
                        while (ZeroSect1.Count > 0)
                        {
                            if (SetSize.Contains(ZeroSect1.Min)) //Если путь пересекается с путем с клеткой с путем человека
                            {
                                if (ZeroSect.Count == 0 && XSect.Count > 0) //Если путь свободен
                                {
                                    intsect = 2;
                                    StepName = ZeroSect1.Min.ToString();
                                }
                            }
                            ZeroSect1.Remove(ZeroSect1.Min);
                        }
                    }

                        
                }
                if (intsect == 1) //Если ничего не найдено выше просто пересекаем путь для человека
                {
                    SetSize = new SortedSet<int>(WinSet);
                    if (SetSize.Max.ToString() == Zero_One)
                    {
                        StepName = SetSize.Min.ToString();
                    }
                    else if (SetSize.Min.ToString() == Zero_One)
                    {
                        StepName = SetSize.Max.ToString();
                    }
                    else
                    {
                        StepName = SetSize.Min.ToString();
                    }
                }
            }
 
            

        }
       
        if (intsect == 0) //Если выше не найден ход
        {
            intsect = 0;
            foreach (SortedSet<int> WinSet in WinSets) //Проверяем короткий путь
            {
                SetSize = new SortedSet<int>(WinSet);
                XSect = new SortedSet<int>(WinSet);
                ZeroSect = new SortedSet<int>(WinSet);
                ZeroSect.IntersectWith(Steps2);
                XSect.IntersectWith(Steps1);
                ExceptX = new SortedSet<int>(WinSet);

                ExceptX.ExceptWith(Steps1);
                if (XSect.Count > intsect && ZeroSect.Count == 0)
                {
                    intsect = XSect.Count;
                    StepName = ExceptX.Min.ToString();
                }


            }
        }
        if (intsect == 0)
        {
            intsect = 0;
            foreach (SortedSet<int> WinSet in WinSets) //Проверяем пустой путь
            {
                SetSize = new SortedSet<int>(WinSet);
                XSect = new SortedSet<int>(WinSet);
                ZeroSect = new SortedSet<int>(WinSet);
                ZeroSect.IntersectWith(Steps2);
                XSect.IntersectWith(Steps1);
                ExceptX = new SortedSet<int>(WinSet);

                ExceptX.ExceptWith(Steps1);
                if (XSect.Count == 0 && ZeroSect.Count == 0)
                {
                    intsect = 1;
                    StepName = ExceptX.Min.ToString();
                }


            }
        }
        if (intsect == 0)
        {
            intsect = 0;
            foreach (SortedSet<int> WinSet in WinSets) //Проверяем путь с наличием ноликов
            {
                SetSize = new SortedSet<int>(WinSet);
                XSect = new SortedSet<int>(WinSet);
                ZeroSect = new SortedSet<int>(WinSet);
                ZeroSect.IntersectWith(Steps2);
                XSect.IntersectWith(Steps1);
                ExceptZero = new SortedSet<int>(WinSet);
                ExceptZero.ExceptWith(Steps2);
                if (XSect.Count == 0 && ZeroSect.Count > 0)
                {
                    intsect = 1;
                    StepName = ExceptZero.Min.ToString();
                }


            }
        } 
        //Делаем ход
        StepMachineContinue();
        intsect = 0;
        countDeadlock = 0;
        foreach (SortedSet<int> WinSet in WinSets) //Проверка на ничью
        {
            SetSize = new SortedSet<int>(WinSet);
            XSect = new SortedSet<int>(WinSet);
            ZeroSect = new SortedSet<int>(WinSet);
            ZeroSect.IntersectWith(Steps2);
            XSect.IntersectWith(Steps1);
            if (XSect.Count > 0 && ZeroSect.Count > 0)
            {
                countDeadlock++;
            }
        }
        if (size == 4)
        {
            if (countDeadlock == 10)
            {
                return;
            }
        }
        if (size == 5)
        {
            if (countDeadlock == 12)
            {
                return;
            }
        }
        countDeadlock = 0;

        //ShortPathTemp = 0;
    }
    /////////////////////////////////////////////////////////
    ///////////////////Конец метода 5////////////////////////
    /////////////////////////////////////////////////////////

    void New()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "New")
                {
                    size = 3;
                    ClearGame();
                    int j = 0;
                    int k = 0;
                    int o = 0;
                    if (coroutine != null) {
                        StopCoroutine(coroutine);
                    }
                    GameObject.Find("Draw").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("WinX").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Win0").GetComponent<MeshRenderer>().enabled = false;
                    for (int i = 0; i < 5; i++)
                    {
                        Row = GameObject.FindGameObjectsWithTag("Row" + (i + 1));
                        GameObject G;
                        foreach (GameObject R in Row)
                        {
                            G = R;
                            while (G.transform.childCount > 0)
                            {
                                G = G.transform.GetChild(0).gameObject;
                                k++;
                            }
                            if (k > 1 && int.Parse(R.tag.Substring(3, 1)) < 4) { 
                                j = 4 - k;
                                o = int.Parse(R.gameObject.tag.Substring(3, 1));
                                R.name = "Field" + ((k + 1 + j) * i + j - i * 2).ToString();
                                R.GetComponent<MeshRenderer>().enabled = true;
                            }
                            else
                            {
                                R.GetComponent<MeshRenderer>().enabled = false;
                                R.name = "Field90" + (i).ToString() + (j).ToString();
                            }
                            k = 0;
                        }
                    }
                }
            }
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        New();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Close")
                {
                    Application.Quit();
                }
                if (!GameOver && !bDemo) { 
                    if (hit.collider.gameObject.name == "Demo")
                    {
                        size = 5;
                        ClearGame();
                        Start();
                        bDemo = true;
                        coroutine = Demo();
                        StartCoroutine(coroutine);
                        return;
                    }
                    if (hit.collider.gameObject.name == "Mode5")
                    {
                        size = 5;
                        ClearGame();
                        Start();
                        return;
                    }
                    if (hit.collider.gameObject.name == "Mode4")
                    {
                        size = 4;
                        ClearGame();
                        Start();
                        return;
                    }
                    if (hit.collider.gameObject.name == "Men1xMachine" || hit.collider.gameObject.name == "MenxMachine1")
                    {
                        ClearGame(); //Очистка игрового поля
                        Start();
                        if (hit.collider.gameObject.name == "Men1xMachine")
                        {
                            Men1XMachine = true; //Человек ходит первым
                        }
                        if (hit.collider.gameObject.name == "MenxMachine1")
                        {
                            MenXMachine1 = true; //Машина ходит первой
                            if (size == 3)
                            {
                                StepMachineFirst();
                            }
                            if (size == 4)
                            {
                                StepMachineFirst4();
                            }
                            if (size == 5)
                            {
                                StepMachineFirst5();
                            }

                        }
                    }
                    if (hit.collider.gameObject.name.Length >= 5 && hit.collider.gameObject.name.Substring(0, 5) == "Field" && !GameObject.Find("X" + hit.collider.gameObject.name.Substring(5, (hit.collider.gameObject.name.Length - 5)))
                                                                                && !GameObject.Find("Zero" + hit.collider.gameObject.name.Substring(5, (hit.collider.gameObject.name.Length - 5))))
                    {
                        Position = hit.collider.gameObject.transform.position;

                        //Сбор шагов игроков в сеты (множества)
                        if (first)
                        {
                            X_Zero_Clone = Instantiate(X, Position, Quaternion.identity) as GameObject;
                            X_Zero_Clone.name = "X" + hit.collider.gameObject.name.Substring(5, (hit.collider.gameObject.name.Length - 5));
                            X_Steps.Add(int.Parse(X_Zero_Clone.name.Substring(1, (X_Zero_Clone.name.Length - 1))));
                            X_Zero_Clone.GetComponent<MeshRenderer>().enabled = true;
                            X_Zero.Add(X_Zero_Clone.name);
                            first = false;
                            if (Men1XMachine)
                            {
                                if (size == 3)
                                {
                                    if (fistsStepForSecond)
                                    {
                                        MachineStep1First();
                                        fistsStepForSecond = false;
                                    }
                                    else
                                    {
                                        Machine1Step(Zero_Steps, X_Steps);
                                    }
                                }
                                if (size == 5)
                                {
                                    if (fistsStepForSecond)
                                    {
                                        MachineStep1First5();
                                        fistsStepForSecond = false;
                                    }
                                    else
                                    {
                                        MachineStep5(Zero_Steps, X_Steps);
                                    }

                                }
                                if (size == 4)
                                {
                                    if (fistsStepForSecond)
                                    {
                                        MachineStep1First4();
                                        fistsStepForSecond = false;
                                    }
                                    else
                                    {
                                        MachineStep5(Zero_Steps, X_Steps);
                                    }

                                }
                            }
                        }
                        else
                        {
                            X_Zero_Clone = Instantiate(Zero, Position, Quaternion.identity) as GameObject;
                            X_Zero_Clone.name = "Zero" + hit.collider.gameObject.name.Substring(5, (hit.collider.gameObject.name.Length - 5));
                            Zero_Steps.Add(int.Parse(X_Zero_Clone.name.Substring(4, (X_Zero_Clone.name.Length - 4))));
                            X_Zero_Clone.GetComponent<MeshRenderer>().enabled = true;
                            X_Zero.Add(X_Zero_Clone.name);
                            first = true;
                            if (MenXMachine1)
                            {
                                if (size == 3)
                                {
                                    Machine1Step(X_Steps, Zero_Steps);
                                }
                                if (size == 4)
                                {
                                    MachineStep5(X_Steps, Zero_Steps);
                                }
                                if (size == 5)
                                {
                                    MachineStep5(X_Steps, Zero_Steps);
                                }
                            }
                        }

                        //Добавление каждого шага игроков

                        //Сравнение сета шагов первого игрока с выигрышными сетами шагов
                        if (X_Steps.Count >= size || Zero_Steps.Count >= size)
                        {
                            foreach (SortedSet<int> WinSet in WinSets)
                            {
                                if (X_Steps.Count >= size)
                                {
                                    SetSize = new SortedSet<int>(WinSet);
                                    SetSize.IntersectWith(X_Steps); //Получение пересечения выигрышного сета с сетом крестиков 
                                    if (SetSize.Count == size) //Eсли размер пересечения равен 3
                                    {
                                        GameObject.Find("WinX").gameObject.GetComponent<MeshRenderer>().enabled = true;
                                        GameOver = true;
                                        break;
                                    }
                                }
                                if (Zero_Steps.Count >= size)
                                {
                                    SetSize = new SortedSet<int>(WinSet);
                                    SetSize.IntersectWith(Zero_Steps); //Получение пересечения выигрышного сета с сетом ноликов
                                    //WinSet.Equals(Equals_Set)
                                    if (SetSize.Count == size) //Eсли размер пересечения равен 3
                                    {
                                        GameObject.Find("Win0").gameObject.GetComponent<MeshRenderer>().enabled = true;
                                        GameOver = true;
                                        break;
                                    }
                                }
                            }
                            if (!GameOver && countDeadlock == WinSets.Count)
                            {
                                GameObject.Find("Draw").gameObject.GetComponent<MeshRenderer>().enabled = true;
                                GameOver = true;
                                return;
                            }
                        }
                        //if (hit.collider.gameObject.name == "Cloze")
                        //{
                        //    Application.Quit();
                        //}
                    }
                    else if (hit.collider.gameObject.name.Substring(0, 3) != "Men" && hit.collider.gameObject.name != "New")  //Если нажали на клетку, где уже есть символ, или на сам существующий символ, или на кнопку режима
                    {
                        Position = hit.collider.gameObject.transform.position;
                        X_Zero_Clone = Instantiate(X, Position, Quaternion.identity) as GameObject;
                        Destroy(X_Zero_Clone.gameObject);
                    }
                }
            }

                

        }

                
        
    }
}
