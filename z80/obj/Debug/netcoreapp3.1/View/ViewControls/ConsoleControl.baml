   M S B A M L   `   `   `  ����>  :z80, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:z80.View.ViewControlsz80.View.ViewControls  5      *    $z80.View.ViewControls.ConsoleControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:z80.View.ViewControls     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��display��5      $��0��5      $
��Wrap=�5      ���#495464
�������$��	Agency FB)�5      $
��12px(�5      ��5      �� *ConsoleResult+ �� UpdateSourceTrigger$ PropertyChanged=� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >��� 5   
   -   5        $��input��5      $��1��5      ���#495464
�������$��	Agency FB)�5       $
��12px(�5!       �� CharacterCasing$ Upper=�5"      ��5      Z� ��5#      �� *ConsoleInput+$ PropertyChanged=� �� $ FindAncestor=�" >�5'      5(      