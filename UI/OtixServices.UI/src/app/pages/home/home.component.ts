import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  ngOnInit(): void {
  }

  /*productSales = [
    {
      "name": "book",
      "value": 5001
    }, {
      "name": "graphic card",
      "value": 7322
    }, {
      "name": "desk",
      "value": 1726
    }, {
      "name": "laptop",
      "value": 2599
    }, {
      "name": "monitor",
      "value": 705
    }
  ];

  //view: any[] = [700, 370];

  // options
  showLegend: boolean = true;
  showLabels: boolean = true;

  animations: boolean = false;
  trimLabels: boolean = false;
  explodeSlices: boolean = false;
  tooltipDisabled: boolean = false;
  gradient: boolean = false;
  isDoughnut: boolean = true;

  legendPosition: any = 'below';

  colorScheme: any = {
    domain: ['#704FC4', '#4B852C', '#B67A3D', '#5B6FC8', '#25706F']
  };

  constructor() { Object.assign(this, { productSalesMulti }) }

  onActivate(data: any): void {
    console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data: any): void {
    console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }

  onSelect(data: any): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }*/
}



/*
export var productSalesMulti = [
  {
    "name": "book",
    "series": [
      {
        "name": "January",
        "value": 125
      }, {
        "name": "February",
        "value": 197
      }, {
        "name": "March",
        "value": 209
      }
    ]
  }, {
    "name": "graphic card",
    "series": [
      {
        "name": "January",
        "value": 210
      }, {
        "name": "February",
        "value": 255
      }, {
        "name": "March",
        "value": 203
      }
    ]
  }, {
    "name": "desk",
    "series": [
      {
        "name": "January",
        "value": 89
      }, {
        "name": "February",
        "value": 105
      }, {
        "name": "March",
        "value": 66
      }
    ]
  }, {
    "name": "laptop",
    "series": [
      {
        "name": "January",
        "value": 178
      }, {
        "name": "February",
        "value": 165
      }, {
        "name": "March",
        "value": 144
      }
    ]
  }, {
    "name": "monitor",
    "series": [
      {
        "name": "January",
        "value": 144
      }, {
        "name": "February",
        "value": 250
      }, {
        "name": "March",
        "value": 133
      }
    ]
  }
]
*/