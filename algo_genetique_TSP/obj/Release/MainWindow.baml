   M S B A M L   `   `   `  ���� M  Ialgo_genetique_TSP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:algo_genetique_TSPalgo_genetique_TSP  #    algo_genetique_TSP.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:algo_genetique_TSP      	  Title  � Title#  �   $	��480��$	��800��$	��480��$	��800��.��� $��	0,0,0,-10q�.+��� -    ��Name$	 run�� 
 Button#���  $
��Left=�$��277,255,0,0q�$	��Top=�$	��227�� J� RenderTransformOrigin$ 0.232,0.718&��� -    ��Name$ result��$
��Left=�$	��128��$��190,294,0,0q�$	��Top=�$	��400�� �� View �� .P���  �� Width$	 400��.����   result_header#���  ��  
 header#���  $
��Left=�$	��230��$��
277,20,0,0q�$	��Top=�$	��227��.���� .+���   nb_generation#���  �� -    ��Name$ nbMaxGen�� �� 	MaxLength$ 5����   fitness#���  �� -   $ minfit��$ 7����   mutations_rate#���  �� -   $ mutsRate��$ 4����   mutation_addRate#���  �� -   $ 
mutAddRate��$ 4����   mutation_deleteRate#���  �� -   $ mutDeleteRate��$ 4����  	 crossoverRate#��� 	 �� -   $ 	crossRate��$ 4��]� $��20��$��0,0,0,0q�$	��Top=�.+�o� $	��Top=�$��20��
�������.@�m�  
 menu_language#��� 
 .@�m� -	    m�Name$ francais��  menu_fr#���  m� -
   $ anglais��  menu_en#���  