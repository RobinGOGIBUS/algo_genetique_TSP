   M S B A M L   `   `   `  ����M  Ialgo_genetique_TSP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:algo_genetique_TSPalgo_genetique_TSP  5   	   #    algo_genetique_TSP.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:algo_genetique_TSP     5   	    	  Title  � Title#  �   5   	   $	��480��6)   $	��800��69   $	��480��6H   $	��800��6X   .��5	      � $��	0,0,0,-10q�6   .+�5
   
   �� -   5         ��Name$	 run��5
   4    
 Button#���  6   $
��Left=�6A   $��277,255,0,0q�6\   $	��Top=�6q   $	��227��6�    J� RenderTransformOrigin$ 0.232,0.718&�6�   6�   �� 5   
   -   5         ��Name$ result��5      $
��Left=�6#   $	��128��6>   $��190,294,0,0q�6K   $	��Top=�6`   $	��400��6x    �� View 5      �� 5      .P�5      ��  �� Width$	 400��6%   .��5      ��   result_header#���  60   5      5      5      �� 5   
    
 header#���  6   $
��Left=�65   $	��230��6P   $��
277,20,0,0q�6]   $	��Top=�6q   $	��227��6�   .��5      �� .+�5      ��   nb_generation#���  6   �� 5      -   5         ��Name$ nbMaxGen��5       �� 	MaxLength$ 5��6,   �� 5        fitness#���  6   �� 5      -   5        $ minfit��5      $ 7��6*   �� 5        mutations_rate#���  6   �� 5      -   5        $ mutsRate��5      $ 4��6,   �� 5        mutation_addRate#���  6   �� 5      -   5        $ 
mutAddRate��5      $ 4��6.   �� 5        mutation_deleteRate#���  6   �� 5      -   5        $ mutDeleteRate��5      $ 4��61   �� 5        	 crossoverRate#��� 	 6   �� 5!      -   5        $ 	crossRate��5!      $ 4��6-   5"      5#      ]� 5%   
   $��20��6   $��0,0,0,0q�6    $	��Top=�61   .+�5&      o� $	��Top=�6   $��20��6(   
�������.@�5'      m�  
 menu_language#��� 
 6   .@�5(      m� -	   5         m�Name$ francais��5(        menu_fr#���  61   6T   m� 5)      -
   5        $ anglais��5)        menu_en#���  60   6S   5*      5+      5,      5-      5.      