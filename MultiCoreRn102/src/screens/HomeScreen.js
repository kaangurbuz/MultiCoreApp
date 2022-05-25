import React from 'react';
import {View, Text, Button} from 'react-native';
export default function HomeScreen({navigation}) {
  const {navigate} = navigation;
  return (
    <View style={{flex: 1, alignItems: 'center', justifiyContent: 'center'}}>
      <View>
        <Text>Home Screen</Text>
      </View>
      <View>
        <Button
          title="Go To Category"
          onPress={() => navigate('Category')}
          color={'wheat'}
        />
        <Button
          title="Go To Product"
          onPress={() => navigate('Product')}
          color={'orchid'}
        />
      </View>
    </View>
  );
}
