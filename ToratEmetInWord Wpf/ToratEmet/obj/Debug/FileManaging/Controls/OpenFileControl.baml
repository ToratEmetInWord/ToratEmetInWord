   M S B A M L   `   `   `  ����D  @ToratEmet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ToratEmet.TreeModelsToratEmet.TreeModels  5      7 clr-namespace:ToratEmet.ControlsToratEmet.Controls  5      (    "ToratEmet.Controls.OpenFileControl   5      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9
treeSource"clr-namespace:ToratEmet.TreeModels     5      2local clr-namespace:ToratEmet.Controls     5      $��RightToLeft=�5	      $��14(�5
      $��Segoe UI Semilight)�5      $��0q�5        � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType �� Padding��%�  '��       '_� �     �� 5   
   " ��6   .�5      ��  � �� �	#FFEFEFEF6+   �� 5       � �� �	#FFACACAC6-   �� 5       �@^�InitialShowDelay$ 0��6@   5      �� 5   
   " _�6   .�5      ��  � �� 5      �� 5      " _�6&   .R�5      �� ���	#FFACACAC$��1q�69   $ 3q�5   !   
�������._�5      �� #��z��6(   $
��Wrap=�5      $	��200��6.   5      5      5      5       5!      .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��auto �6   �� 5%      $��* �6    � ColumnDefinitions 5'   
   �� 5(      $
��auto �6   �� 5)      $��* �6   �� 5*      $
��auto �6   .+�5-   
   �� -   5         ��Name$ SearchComboBox��5-      $��0��5/      $��0��6   $��0��6*   ��5-   +   �� *
ResultList+
	 � Tag	 5.      �� *
TargetId+  51      
 �� DataType'   !ToratEmet.TreeModels.FileTreeItem ��Name �� Orientation �� RelativeSource �� AncestorType �� Path �� BindsDirectlyToSource��%  (��       52      *, +)'��     �� 6   "
  6   .R�53      �� $ FolderItemPanel��6!   $ 
Horizontal=�6:   .+�54      �� $
��🗎��6$   $��0,0,3,0q�6.   �� 55      ��6$   �� *Name+�� 56      ���	#FFA2A4A5��6$   ��  �� " ��$	 Tag�57   $   58      59      �� 5:      " ��6   .�5;      -   5        �� 5<       �@�Tag 6,   ��  . �� 5=       � ��$	 300��61   �� 5>       �@�ToolTip 60   ��  �� *Self+$ Content�5?      5@      5A      �� 5C   
   -   5         ��Name$ SearchTextBox��5C       � ToolTip$� �כדי לפתוח מיקום מדוייק בספר יש להזין את הכתובת המדוייקת על ידי הפרדה של פסיקים (לדוגמא: "בראשית, יג, יד").��5D      $��0��5E      $��1��6   $��3q�5F      5H      �� 5K   
   $ 
Horizontal=�6   $��0��5L      $��2��6   $��3q�5M      .+�5N      �� -   5        $ RecentSearchesCombo��5N      $��0��5O      5Q      �� 5R      -   5         ��Name$ SearchButton��5R      $��חפש��6+   $��1,1,0,1q�5S      $��5,0,2,2q�5T      5U      �� 5V      -   5        $ RecentSearchesButton��5V      $	��⏷��63   $# חיפושים אחרונים��5W      $��8(�5X      $��0,0,2,2q�5Y      $��0,1,1,1q�5Z      5[      5\      R� 5^   
   -   5         R�Name$ treeView��5^      $��1��5_      $��3��6   $��0,2,0,0q�5`      $��	0,0.1,0,0q�5a        5c      )   #ToratEmet.TreeModels.FolderTreeItem �� ItemsSource �� Mode��%�  (��       5e   +   *, +)(�� #    5m   +   *, +)'Q�     �� 5e      "
  6+    6Y   �� *
Children+.R�5f      �� $ FolderItemPanel��6!   $ 
Horizontal=�6:   .+�5g      �� $;��5/ToratEmet;component/Resources/StandingFolderIcon.ico��6    $��18��5h      $��0,0,3,0q�6%   �� 5i      ��6$   �� *Name+5j      5k      �� 5m      "
  6+    6W   �� *
Children+.R�5n      �� $ FolderItemPanel��6!   $ 
Horizontal=�6:   .+�5o      �� $
��🗎��6$   $��0,0,3,0q�6.   �� 5p      ��6$   �� *Name+5q      5r      �� 5t      " Q�6   .�5u      ��  �@Q�
IsExpanded 63   �� *
IsExpanded+$ TwoWay=�5v      5w      5x      5y      5z      