   M S B A M L   `   `   `  ����E  AClientChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SharpChat.Views.ChatSharpChat.Views.Chat  5      '    !SharpChat.Views.Chat.ChatGridView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:SharpChat.Views.Chat     5      .��5	      �� $��0��6   
���iii�$��1q�61   ._�5
   
   �   � ColumnDefinitions  5      �� 5      $	��200��6#   $
��Auto �62   �� 5      �� 5      $	��200��6#   $
��Auto �62   .+�5      � $��0��6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      �� $��0��6   
���iii�$��1q�6=   ._�5      �� -   5         ��Name$ ServerStateLine��5   %   5      �� 5      $��1��6   
���iii�$��1q�6=   ._�5      �� -   5        $ ChatCollection��5   %   5      5      � 5      $��1��6    5      �� 5      $
��Auto �6$   �� 5      �� 5       $
��Auto �6$   .+�5"      �� $��0��6   
���iii�$��1q�6=   ._�5#      �� -   5        $ HeadChatLine��5#   %   5$      �� 5%      $��1��6   
���iii�$��1q�6=   ._�5&      �� -   5        $ MessagesFeed��5&   %   5'      �� 5(      $��2��6   
���iii�$��1q�6=   ._�5)      �� -   5        $ EditChatLine��5)   %   5*      5+      � 5-      $��2��6    5.      �� 5/      $
��Auto �6$   �� 50      .+�52      �� $��0��6   
���iii�$��1q�6=   ._�53      �� -   5        $ MyProfileLine��53   %   54      �� 55      $��1��6   
���iii�$��1q�6=   ._�56      �� -   5        $ Target��56   %   57      58      5:      5;      5<      