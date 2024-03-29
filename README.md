<p align="center">
  <h1 align="center">Concurrent programming</h1>
  
  <a><strong>Warning: The project is still in progress and will be updated in the near future</strong></a>
  
  <p align="center"><img src="images/image_2.png" alt="Logo" width="100" height="100"></p>
  
  
  <p align="center">
    Bouncing balls!
  <br/>
  <br/>
  <a href="https://github.com/GoldenKacper/Concurrent-Programming"><strong>Explore the docs »</strong></a>
  <br/>
  <br/>
  <a href="https://raw.githubusercontent.com/GoldenKacper/Concurrent-Programming/main/videos/tutorial.mp4">View short tutorial</a>
  .
  <a href="https://github.com/GoldenKacper/Concurrent-Programming/tree/main/featureRequest">Feature Requests</a>
  </p>
</p> 

## Table Of Contents

* [About the Project](#about-the-project)
* [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [License](#license)
* [Authors](#working-group-authors)
* [Acknowledgements](#acknowledgements)

## About The Project

![Screen Shot](images/image_1.png)

Our task was to create a program of balls moving on the screen in C#, using asynchronous and concurrent programming techniques.
The project is that the user selects the number of balls to generate and presses the button, then the balls are generated in random places and their task is to move and bounce in a realistic way from the barriers and themselves.

Here's why:

* We wanted to learn more and test the concurrency programming ourselves.
* Using the simple idea of bouncing balls to practice programming, but in an interesting and new way for us.
* Watching the balls bounce off each other is really satisfying: try it for yourself ;-)

Despite such a simple idea, it might seem that the project will be trivial, however it turned out to be an interesting challenge

A list of commonly used resources that we find helpful are listed in the acknowledgements.

## Built With

The idea was to make a program in C# using the MVVM pattern to connect the data with the view. Finally, our project is divided into 3 layers: data, logic and presentation. And the presentation layer itself is made according to the MVVM pattern and is divided into: model, viewmodel, view. The next step was to implement multi-threading. We wanted each ball to be a separate thread and move independently. We used the critical section for data and logic to avoid various problems. we implement reactive and interactive user-computer interaction. Our graphical user interface (GUI) is made using XAML. In addition also Dependency Injections and asynchronous programming is used.

## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

### Installation

1. Clone the repo

```sh
git clone https://github.com/GoldenKacper/Concurrent-Programming.git
```

2. Open net6.0-windows folder

 Folder is in the following location. Remember this is a relative path.
 <br/>
 Type this command in CMD in the folder where you have cloned the repo. 
 
 ```sh
cd Concurrent-Programming\Presentation\bin\Debug\net6.0-windows
```

3. Run Presentation.exe file

``` sh
.\Presentation.exe
```

## Usage

If you already have a project prepared, we refer you to the quick guide
<a href="https://raw.githubusercontent.com/GoldenKacper/Concurrent-Programming/main/videos/tutorial.mp4">View short tutorial</a>


## Roadmap

See the [open issues](https://github.com/GoldenKacper/Concurrent-Programming/issues) for a list of proposed features (and known issues).

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.
* If you have suggestions for adding or removing projects, feel free to [open an issue](https://github.com/GoldenKacper/Concurrent-Programming/issues/new) to discuss it, or directly create a pull request after you edit the *README.md* file with necessary changes.
* Please make sure you check your spelling and grammar.
* Create individual PR for each suggestion.

We can implement any suggestions only after we finish the project at the university, i.e. from the summer of 2023

### Creating A Pull Request

1. Fork the Project
2. Create your Feature Branch (`git checkout -b suggestions`)
3. Commit your Changes (`git commit -m 'Add some exampleSuggestion`)
4. Push to the Branch (`git push origin suggestions`)
5. Open a Pull Request

## License

See [LICENSE](https://github.com/GoldenKacper/Concurrent-Programming/blob/main/LICENSE.md) for more information.

## Working Group (Authors)

| Name Surname (initials) | GUID                                     |
| ----------------------- | ---------------------------------------- |
| Kacper Jagodziński      | `{44cde337-333b-4960-bd5c-8a18c9b5b97b}` |
| Adam Kruszyński         | `{cb2cfa5a-5396-4921-be82-b7c9f2beec61}` |

## Acknowledgements

* [GithubProject](https://github.com/mpostol/TP)
* [Wiki](https://en.wikipedia.org/wiki/Elastic_collision)
