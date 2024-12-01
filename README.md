# editor-average-word-length
A web service in Visual Basic which provides the average word length in a provided string.
## Usage
First, build and run the service:
### Docker
- `docker build -t average-word-length .`
- `docker run -p 80:80 average-word-length`

### Directly
- `cd src/AverageWordLength`
- `dotnet build`
- `dotnet run`

Then open `http://localhost:80/average-word-length?text=your_text_here` in your favourite browser.
## Notes
- Usernames in commit history - MegaBytesMe is my other git username (on GitHub)... I've forgotten to do the `git config --local user.email ""` and `git config --local user.name ""` commands whilst editing this repo on my PC! Happy to discuss if need be (and can prove this too).