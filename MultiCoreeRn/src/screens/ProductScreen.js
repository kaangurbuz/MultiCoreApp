import React, {Component} from 'react';
import {
  View,
  Text,
  Button,
  StyleSheet,
  ActivityIndicator,
  ScrollView,
  TouchableOpacity,
} from 'react-native';
import {DataTable} from 'react-native-paper';

export default class ProductScreen extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: true,
      dataSource: [],
    };
  }
  componentDidMount() {
    return fetch(
      'https://multicoreapp-api.conveyor.cloud/api/Product/categoryall',
    )
      .then(response => response.json())
      .then(responseJson => {
        this.setState({isLoading: false, dataSource: responseJson});
      })
      .catch(error => console.log('HATA : ' + error));
  }
  render() {
    if (this.state.isLoading) {
      return (
        <View style={{flex: 1, padding: 20}}>
          <ActivityIndicator />
        </View>
      );
    } else {
      return (
        <ScrollView style={styles.container}>
          <DataTable>
            <DataTable.Header>
              <DataTable.Title style={{display: 'none'}}>Id</DataTable.Title>
              <DataTable.Title>Product Name</DataTable.Title>
              <DataTable.Title>Stock</DataTable.Title>
              <DataTable.Title>Price</DataTable.Title>
              <DataTable.Title>Category Name</DataTable.Title>
            </DataTable.Header>

            {this.state.dataSource.map((item, key) => (
              <TouchableOpacity key={key}>
                <DataTable.Row>
                  <DataTable.Cell style={{display: 'none'}}>
                    {item.id}
                  </DataTable.Cell>
                  <DataTable.Cell>{item.name}</DataTable.Cell>
                  <DataTable.Cell>{item.stock}</DataTable.Cell>
                  <DataTable.Cell>{item.price}</DataTable.Cell>
                  <DataTable.Cell>{item.category.name}</DataTable.Cell>
                </DataTable.Row>
              </TouchableOpacity>
            ))}
          </DataTable>
        </ScrollView>
      );
    }
  }
}

const styles = StyleSheet.create({
  container: {
    paddingTop: 100,
    paddingHorizontal: 30,
  },
});

// export default function CategoryScreen(navigation) {
//   const {navigate} = navigation;
//   return (
//     <View style={{flex: 1, alignItems: 'center', justifiyContent: 'center'}}>
//       <View>
//         <Text>CategoryScreen</Text>
//       </View>
//     </View>
//   );
// }
