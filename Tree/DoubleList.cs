﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class DoubleList
    {
        public override string ToString()
        {
            return Head.Data.ToString();
        }
        public Element Head { get; set; }//      
      
        //преобразование входного слова в массив char
        public void AddWord(string s)
        {
            if (Head == null)
            {
                Head = new Element();
                AddSymbols(s.ToCharArray());
             
            }
            else
            {
                AddSymbols(s.ToCharArray());
            }
        }
      //метод добавления, если уже известно, что внизу нет ничего
        public void AddCascadElements(int index,Element element,char[] arrayOfSymbols)
        {
            Debug.WriteLine("Метод добавления каскадом");
            var time = element;
            for (int i = index; i < arrayOfSymbols.Length; i++)
            {
                var temrory = new Element
                {
                    Data = arrayOfSymbols[i]
                };
                time.Down = temrory;
                time = temrory;
            }
            var temprory = new Element
            {
                Data = '*',
                Down = null
            };
            time.Down = temprory;
        }
        //добавление слов
        public void AddSymbols(char[] arrayOfSymbols)
        {
            Debug.WriteLine("AddSymbols");
            var temrory = Head;
            for (int i = 0; i < arrayOfSymbols.Length; i++)
            {             
                if (!SerchSymbolRight(Head, arrayOfSymbols[i]))
                {
                    temrory =  AddSymbolRightEnd(temrory, arrayOfSymbols[i]);
                    AddCascadElements(i+1, temrory, arrayOfSymbols);
                    break;
                }
                {
                    temrory = GetReferencOfElement(temrory, arrayOfSymbols[i]);
                }               
            } 
        }
        //добавление в случе, если не найден справа
        private Element AddSymbolRightEnd(Element element,char symbol)
        {
            Debug.WriteLine("AddSymbolRightEnd");

            Element temrory = new Element();
            while(element.Right != null)
            {
                element = element.Right;
            }
            element.Right = temrory;
            temrory.Data = symbol;
            temrory.Right = null;
            temrory.Down = null;
            return temrory;
        }
        //поиск эллемента справа
         public bool SerchSymbolRight(Element Upster,char symbol)
        {
            Debug.WriteLine("SerchSymbolRight");
            while (Upster.Right != null)
            {
                if(Upster.Data == symbol)
                {
                    return true;
                }
                else
                {
                    Upster = Upster.Right; 
                }
            }
            return false;
        }
        //созданеи элемента снизу
        public void CreatDownElement(Element element,char symbol)
        {
            Debug.WriteLine("CreatDownElement");
            var temprory = new Element();
            element.Down = temprory;
            temprory.Data = symbol;
            temprory.Right = null;
            temprory.Down = null;
        }

         private Element GetReferencOfElement(Element Upster, char symbol)
        {
            Debug.WriteLine("GetReferencOfElement");
            var temprory = Upster;
            while (temprory.Data != symbol)
            {
                temprory = temprory.Right;
            }
            return temprory;
        }
    }
}