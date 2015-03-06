﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtificialIntelligence.Tree;

namespace UnitTesting
{
    [TestClass]
    public class TreeTests
    {
        /// <summary>
        /// Test to check that the properties are correctly set when the TreeNode object is instantiated.
        /// </summary>
        [TestMethod]
        public void EmptyConstr_Test()
        {
            TreeNode<int> t_empty = new TreeNode<int>();

            Assert.IsNull(t_empty.Parent);
            Assert.IsInstanceOfType(t_empty.Children, typeof(TreeNodeList<int>));
            Assert.AreEqual<int>(0, t_empty.Profondeur);            
        }

        /// <summary>
        /// Test to check that the properties are correctly set when the TreeNode object is instantiated.
        /// </summary>
        [TestMethod]
        public void ValueConstr_Test()
        {
            int value = 5;
            TreeNode<int> t_value = new TreeNode<int>(value);

            Assert.IsNull(t_value.Parent);
            Assert.IsInstanceOfType(t_value.Children, typeof(TreeNodeList<int>));
            Assert.AreEqual<int>(0, t_value.Profondeur);
            Assert.AreEqual<int>(value, t_value.Value);
        }

        /// <summary>
        /// Test to check that the properties are correctly set when the TreeNode object is instantiated.
        /// </summary>
        [TestMethod]
        public void FullConstr_Test()
        {
            int value = 5;
            
            TreeNode<int> t_racine = new TreeNode<int>(value);
            TreeNode<int> t_full = new TreeNode<int>(value, t_racine);

            Assert.IsNotNull(t_full.Parent);
            Assert.AreEqual<TreeNode<int>>(t_racine, t_full.Parent);
            Assert.IsInstanceOfType(t_full.Children, typeof(TreeNodeList<int>));
            Assert.AreEqual<int>(t_racine.Profondeur + 1, t_full.Profondeur);
            Assert.AreEqual<int>(value, t_full.Value);

            //Create an array of the children, and take the first one.
            TreeNode<int> [] a_racine = t_racine.Children.ToArray();
            TreeNode<int> first_node = a_racine[0];

            Assert.AreEqual<TreeNode<int>>(first_node, t_full);
        }
    }
}
