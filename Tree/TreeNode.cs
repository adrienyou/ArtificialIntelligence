﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.Tree
{
    public class TreeNode<T>
    {
        private TreeNode<T> _Parent;
        private TreeNodeList<T> _Children;
        private T _Value;
        private int _Profondeur;

        // Constructors for a TreeNode
        public TreeNode()
        {
            _Parent = null;
            _Children = new TreeNodeList<T>(this);
            _Profondeur = 0;
        }

        public TreeNode(T Value)
        {
            _Value = Value;
            _Parent = null;
            _Children = new TreeNodeList<T>(this);
            _Profondeur = 0;
        }

        public TreeNode(T Value, TreeNode<T> Parent)
        {
            _Value = Value;
            _Parent = Parent;
            _Children = new TreeNodeList<T>(this);
            _Profondeur = Parent.Profondeur + 1;

            Parent.Children.Add(this);
        }
        
        // Fields accessors
        public TreeNode<T> Parent
        {
            get { return _Parent; }
            set
            {
                if (value == null)
                    return;
                _Parent = value; 
            }
        }

        public TreeNodeList<T> Children
        {
            get { return _Children; }
            set
            {
                if (value == null)
                    return;

               _Children = value;
            }
        }

        public T Value
        {
            get { return _Value; }
            set
            {
                if (value == null && _Value == null)
                    return;

                if (value != null && _Value != null && value.Equals(_Value))
                    return;

                _Value = value;
            }
        }

        public int Profondeur
        {
            get { return _Profondeur; }
            set
            {
                if (value == null)
                    return;

                _Profondeur = value;
            }
        }
    }
}

